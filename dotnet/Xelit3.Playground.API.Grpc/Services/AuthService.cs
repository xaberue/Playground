using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Xelit3.Playground.API.Grpc.Security;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Grpc.Services;

public class AuthService : Auth.AuthBase
{

    private readonly AuthSettings _authSettings;
    private readonly ITokenHelper _tokenHelper;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;


    public AuthService(AuthSettings authSettings, ITokenHelper tokenHelper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _authSettings = authSettings;
        _tokenHelper = tokenHelper;
        _signInManager = signInManager;
        _userManager = userManager;
    }


    public override async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, ServerCallContext context)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid username or password"));

        var token = _tokenHelper.Generate(user, new[] { "Admin" }, new[] { new Claim("Admin", "true") });
        return new AuthenticationResponse { AccessToken = token.Token, ExpiresIn = (int)_authSettings.MinutesToExpire };
    }
}
