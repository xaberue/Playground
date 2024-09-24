using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Xelit3.Playground.ApiKey.Auth;


public class ApiKeyAuthFilter : IAuthorizationFilter
{

    private readonly IConfiguration _configuration;


    public ApiKeyAuthFilter(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }


    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(Constants.ApiKeyHeaderName, out var extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("API Key is missing");
            return;
        }

        var apiKey = _configuration.GetValue<string>(Constants.ApiKeySectionName)
            ?? throw new ArgumentNullException("API Key must be configured");

        if (!apiKey.Equals(extractedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid API Key");
            return;
        }
    }

}


public class ApiKeyAuthEndpointFilter : IEndpointFilter
{

    private readonly IConfiguration _configuration;


    public ApiKeyAuthEndpointFilter(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }


    public async ValueTask<Object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(Constants.ApiKeyHeaderName, out var extractedApiKey))
            return new UnauthorizedHttpObjectResult("API Key is missing");

        var apiKey = _configuration.GetValue<string>(Constants.ApiKeySectionName)
            ?? throw new ArgumentNullException("API Key must be configured");

        if (!apiKey.Equals(extractedApiKey))
            return new UnauthorizedHttpObjectResult("Invalid API Key");

        return await next(context);
    }
}