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
        /* TODO:
         * [X] 1. Implement new mechanism for Identity in .NET8
         * [X] 2. Implement new mechanism for JWT Auth in .NET
         * https://www.youtube.com/watch?v=mgeuh8k3I4g&list=WL&index=7
         * https://www.youtube.com/watch?v=sZnu-TyaGNk&list=WL&index=9&t=11s
         * [X] 3. Move if needed implementation for JWT Auth from ChustaSoft
         * https://github.com/ChustaSoft/Authorization/blob/main/NuGet/ChustaSoft.Tools.Authorization.JWTBearer/Helpers/TokenHelper.cs
         * [ ] 4. Finnish impl here
         */
        var user = await _userManager.FindByNameAsync(request.Username);

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        var token = _tokenHelper.Generate(user, new[] { "Admin" }, new[] { new Claim("Admin", "true") });

        return new AuthenticationResponse { AccessToken = token.Token, ExpiresIn = (int)_authSettings.MinutesToExpire };
    }
}
