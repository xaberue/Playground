using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Grpc.Security;


public interface ITokenHelper
{
    TokenInfo Generate(AppUser user, IEnumerable<string> roles, IEnumerable<Claim> claims);
}


public class TokenHelper : ITokenHelper
{

    private readonly AuthSettings _authSettings;


    public TokenHelper(AuthSettings authSettings)
    {
        _authSettings = authSettings;
    }


    public TokenInfo Generate(AppUser user, IEnumerable<string> roles, IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var allClaims = GenerateClaims(user, roles, claims);
        var tokenDescriptor = GenerateTokenDescriptor(allClaims);
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenInfo(tokenHandler.WriteToken(token), token.ValidTo);
    }


    private SecurityTokenDescriptor GenerateTokenDescriptor(Claim[] claims)
    {
        var signingKey = SecurityKeyHelper.GetSecurityKey(_authSettings.SecretKey);
        var expiringDate = DateTime.UtcNow.AddMinutes(_authSettings.MinutesToExpire);
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        return new SecurityTokenDescriptor
        {
            Issuer = _authSettings.SiteName,
            Audience = _authSettings.SiteName,
            Subject = new ClaimsIdentity(claims),
            Expires = expiringDate,
            SigningCredentials = signingCredentials
        };
    }

    private Claim[] GenerateClaims(AppUser user, IEnumerable<string> roles, IEnumerable<Claim> claims)
    {
        var claimsBuilder = new ClaimsIdentityBuilder(user)
            .AddRoles(roles)
            .AddClaims(claims);

        return claimsBuilder.Build();
    }
}
