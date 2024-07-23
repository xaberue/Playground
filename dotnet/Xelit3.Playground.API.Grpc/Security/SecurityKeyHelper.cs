using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Xelit3.Playground.API.Grpc.Security;

public static class SecurityKeyHelper
{

    public static SecurityKey GetSecurityKey(string privateKey)
    {
        var secretKeyBytes = Encoding.UTF8.GetBytes(privateKey);
        var signingKey = new SymmetricSecurityKey(secretKeyBytes);

        return signingKey;
    }

}
