using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;

namespace Xelit3.Playground.Hmac.Server.Hmac;


/// <summary>
/// Middleware class for handling HMAC authentication
/// </summary>
public class HMACAuthenticationMiddleware
{

    private readonly RequestDelegate _next;
    private readonly IMemoryCache _memoryCache;


    // Nonce expiry time to prevent reuse of nonces
    private static readonly TimeSpan NonceExpiry = TimeSpan.FromMinutes(5);

    // Timestamp tolerance to allow slight time differences between client and server
    private static readonly TimeSpan TimestampTolerance = TimeSpan.FromMinutes(5);


    // Constructor to initialize the middleware with the next request delegate and memory cache
    public HMACAuthenticationMiddleware(RequestDelegate next, IMemoryCache memoryCache)
    {
        _next = next;
        _memoryCache = memoryCache;
    }


    // Main method to handle each request and perform HMAC validation
    public async Task Invoke(HttpContext context)
    {
        // Check if the Authorization header is present
        if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header missing");
            return;
        }

        // Check if the Authorization header starts with "HMAC "
        if (!authHeader.ToString().StartsWith("HMAC ", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid Authorization header");
            return;
        }

        // Extract token parts from the Authorization header
        var tokenParts = authHeader.ToString().Substring("HMAC ".Length).Trim().Split('|');
        if (tokenParts.Length != 4)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid HMAC format");
            return;
        }

        var clientId = tokenParts[0]; // Extract client ID
        var token = tokenParts[1];    // Extract HMAC token
        var nonce = tokenParts[2];    // Extract nonce
        var timestamp = tokenParts[3]; // Extract timestamp

        // Validate the client ID and get the secret key
        if (!ClientSecrets.Secrets.TryGetValue(clientId, out var secretKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid client ID");
            return;
        }

        // Validate the timestamp to prevent replay attacks
        if (!DateTimeOffset.TryParse(timestamp, out var requestTime) || Math.Abs((DateTimeOffset.UtcNow - requestTime).TotalMinutes) > TimestampTolerance.TotalMinutes)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid or expired timestamp");
            return;
        }

        // Add the nonce to the cache to prevent reuse
        if (!AddNonce(nonce))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Nonce already used");
            return;
        }

        // Read the request body for POST and PUT requests
        var requestBody = string.Empty;
        if (context.Request.Method == HttpMethod.Post.Method || context.Request.Method == HttpMethod.Put.Method)
        {
            //The context.Request.EnableBuffering(); method is used to allow the HTTP request body to be read multiple times.
            //In the context of HMAC authentication middleware, it is necessary because the request body needs to be read to compute the HMAC for validation,
            //but it must also be available to any downstream middleware or the actual API controller.
            context.Request.EnableBuffering();

            //Read the request body
            //Using a StreamReader, we can read the entire request body into a string.
            using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
            {
                //This reads the request body stream to the end.
                requestBody = await reader.ReadToEndAsync();

                //The statement context.Request.Body.Position = 0; is used to reset the position of the request body stream to the beginning.
                //This is important because, by default, the request body stream in ASP.NET Core is a forward-only stream,
                //meaning once you read it, it cannot be read again unless you explicitly reset its position.
                context.Request.Body.Position = 0;
            }
        }

        // Validate the HMAC token
        var isValid = ValidateToken(token, nonce, timestamp, context.Request, requestBody, secretKey);

        if (!isValid)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid HMAC token");
            return;
        }

        // Call the next middleware in the pipeline
        await _next(context);
    }

    // Method to add a nonce to the cache
    private bool AddNonce(string nonce)
    {
        if (_memoryCache.TryGetValue(nonce, out _))
        {
            return false; // Nonce already used
        }

        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(NonceExpiry);
        _memoryCache.Set(nonce, true, cacheEntryOptions);
        return true;
    }

    // Method to validate the HMAC token
    private bool ValidateToken(string token, string nonce, string timestamp, HttpRequest request, string requestBody, string secretKey)
    {
        var path = Convert.ToString(request.Path);
        var requestContent = new StringBuilder()
            .Append(request.Method.ToUpper())
            .Append(path.ToUpper())
            .Append(nonce)
            .Append(timestamp);

        // Include the request body for POST and PUT methods
        if (request.Method == HttpMethod.Post.Method || request.Method == HttpMethod.Put.Method)
        {
            requestContent.Append(requestBody);
        }

        var secretBytes = Encoding.UTF8.GetBytes(secretKey);
        var requestBytes = Encoding.UTF8.GetBytes(requestContent.ToString());

        // Compute the HMAC hash
        using var hmac = new HMACSHA256(secretBytes);
        var computedHash = hmac.ComputeHash(requestBytes);
        var computedToken = Convert.ToBase64String(computedHash);

        return token == computedToken;
    }
}