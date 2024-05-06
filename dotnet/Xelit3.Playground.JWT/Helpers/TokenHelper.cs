using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Xelit3.Playground.JWT.Helpers;

public interface ITokenHelper
{
    TokenInfo Generate(AppUser user, IEnumerable<string> roles, IEnumerable<Claim> claims, string privateKey);
}


public class TokenHelper : ITokenHelper
{

    private readonly AuthorizationSettings _authorizationSettings;


    public TokenHelper(AuthorizationSettings authorizationSettings)
    {
        _authorizationSettings = authorizationSettings;
    }


    public TokenInfo Generate(AppUser user, IEnumerable<string> roles, IEnumerable<Claim> claims, string privateKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var allClaims = GenerateClaims(user, roles, claims);
        var tokenDescriptor = GenerateTokenDescriptor(allClaims, privateKey);
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenInfo(tokenHandler.WriteToken(token), token.ValidTo);
    }


    private SecurityTokenDescriptor GenerateTokenDescriptor(Claim[] claims, string privateKey)
    {
        var signingKey = SecurityKeyHelper.GetSecurityKey(privateKey);
        var expiringDate = DateTime.UtcNow.AddMinutes(_authorizationSettings.MinutesToExpire);
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        return new SecurityTokenDescriptor
        {
            Issuer = _authorizationSettings.SiteName,
            Audience = _authorizationSettings.SiteName,
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


public record TokenInfo
{

    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }


    public TokenInfo(string token, DateTime expirationDate)
    {
        Token = token;
        ExpirationDate = expirationDate;
    }

}

public record AuthorizationSettings
{
    public Double MinutesToExpire { get; internal set; } = 10;
    public String SiteName { get; internal set; } = "https://localhost:7066";
}