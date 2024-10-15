using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Xelit3.Playground.Hmac.Client;


public class HMACHelper
{

    /// <summary>
    /// Method to generate HMAC token
    /// </summary>
    /// <param name="method"></param>
    /// <param name="path"></param>
    /// <param name="clientId"></param>
    /// <param name="secretKey"></param>
    /// <param name="requestBody"></param>
    /// <returns></returns>
    public static string GenerateHmacToken(string method, string path, string clientId, string secretKey, string requestBody = "")
    {
        // Generate a unique nonce
        var nonce = Guid.NewGuid().ToString();

        // Get the current UTC timestamp in ISO 8601 format
        var timestamp = DateTime.UtcNow.ToString("o");

        // Build the request content by concatenating method, path, nonce, and timestamp
        var requestContent = new StringBuilder()
            .Append(method.ToUpper())
            .Append(path.ToUpper())
            .Append(nonce)
            .Append(timestamp);

        // If the HTTP method is POST or PUT, append the request body to the request content
        if (method == HttpMethod.Post.Method || method == HttpMethod.Put.Method)
        {
            requestContent.Append(requestBody);
        }

        // Convert secret key and request content to bytes
        var secretBytes = Encoding.UTF8.GetBytes(secretKey);
        var requestBytes = Encoding.UTF8.GetBytes(requestContent.ToString());

        // Create HMACSHA256 instance with the secret key
        using var hmac = new HMACSHA256(secretBytes);

        // Compute the hash of the request content
        var computedHash = hmac.ComputeHash(requestBytes);

        // Convert the computed hash to base64 string (token)
        var computedToken = Convert.ToBase64String(computedHash);

        // Concatenate clientId, computedToken, nonce, and timestamp to form the final token
        return $"{clientId}|{computedToken}|{nonce}|{timestamp}";
    }

}