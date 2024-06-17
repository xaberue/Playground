using FastEndpoints;

namespace Xelit3.Playground.API.FastEndpoints;

public class HelloWorldEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/hello-world");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest r, CancellationToken c)
    {
        await SendAsync(new($"{r.FirstName} {r.LastName}", "Welcome to FastEndpoints..."));
    }
}


public record MyRequest(string FirstName, string LastName);

public record MyResponse(string FullName, string Messag);
