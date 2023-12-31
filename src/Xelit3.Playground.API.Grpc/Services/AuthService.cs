using Grpc.Core;

namespace Xelit3.Playground.API.Grpc.Services;

public class AuthService : Auth.AuthBase
{
    public override Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, ServerCallContext context)
    {
        /* TODO:
         * [X] 1. Implement new mechanism for Identity in .NET8
         * [ ] 2. Implement new mechanism for JWT Auth in .NET
         * https://www.youtube.com/watch?v=mgeuh8k3I4g&list=WL&index=7
         * https://www.youtube.com/watch?v=sZnu-TyaGNk&list=WL&index=9&t=11s
         * [ ] 3. Move if needed implementation for JWT Auth from ChustaSoft
         * https://github.com/ChustaSoft/Authorization/blob/main/NuGet/ChustaSoft.Tools.Authorization.JWTBearer/Helpers/TokenHelper.cs
         * [ ] 4. Finnish impl here
         */



        return base.Authenticate(request, context);
    }
}
