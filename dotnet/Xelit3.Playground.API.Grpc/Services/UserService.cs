using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace Xelit3.Playground.API.Grpc.Services;

[Authorize]
public class UserService : User.UserBase
{
    public override Task<HelloUserResponse> SayHello(HelloUserRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloUserResponse { Message = $"Hello {request.Name}" });
    }
}
