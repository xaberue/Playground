using System.Net;

namespace Xelit3.Playground.ApiKey.Auth;

public class UnauthorizedHttpObjectResult : IResult, IStatusCodeHttpResult
{

    private readonly object _body;

    public int? StatusCode => (int)HttpStatusCode.Unauthorized;

    public UnauthorizedHttpObjectResult(object body)
    {
        _body = body;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        httpContext.Response.StatusCode = StatusCode!.Value;
        
        if (_body is string s)
        {
            await httpContext.Response.WriteAsync(s);
            return;
        }

        await httpContext.Response.WriteAsJsonAsync(_body);
    }
}
