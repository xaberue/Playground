using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Grpc.Security;

public class ClaimsIdentityBuilder
{

    private ICollection<Claim> _claims;


    internal ClaimsIdentityBuilder(AppUser user)
    {
        _claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
    }


    internal ClaimsIdentityBuilder AddRoles(IEnumerable<string> roles)
    {
        foreach (var role in roles)
            _claims.Add(new Claim(ClaimTypes.Role, role));

        return this;
    }

    internal ClaimsIdentityBuilder AddClaims(IEnumerable<Claim> claims)
    {
        foreach (var claim in claims)
            _claims.Add(claim);

        return this;
    }

    public Claim[] Build() => _claims.ToArray();


}