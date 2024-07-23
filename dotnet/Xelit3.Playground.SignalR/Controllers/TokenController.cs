using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xelit3.Playground.SignalR.Models;
using Xelit3.Playground.SignalR.Services;

namespace Xelit3.Playground.SignalR.Controllers;


[ApiController]
[Route("/auth/token")]
public class TokenController : Controller
{

    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;


    public TokenController(UserManager<AppUser> userManager, IUserService userService, JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _userService = userService;
        _jwtSettings = jwtSettings;
    }


    [HttpPost]
    public async Task<IActionResult> GetToken(AuthenticateRequest request)
    {
        var internalUser = _userService.Get(request.UserId);

        var user = await _userManager.FindByNameAsync(internalUser.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return Forbid();
        }

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Sid, user.Id),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
    };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        //test
        //claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(720),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return Ok(new
        {
            AccessToken = jwt
        });
    }
}
