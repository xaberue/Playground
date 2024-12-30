using System.Security.Claims;

namespace Xelit3.Playground.ResultPattern;

public class UserProvisioningService(CreateUserService createUserService)
{
    public UserAccount ProvisionUser(ExternalLoginInfo info)
    {
        // Attempt to fetch the claims associated with the provided info
        Claim[]? claims = GetClaimValues(info);

        // We've retrieved the claims based on the login info, but we can't
        // necessarily trust that, so validate and sanitize the claims
        Claim[]? validatedClaims = ValidateClaims(claims);

        // Now we have the claims, fetch the appropriate tenant ID based on the claims
        Guid tenantId = GetTenantId(validatedClaims);

        // Combine the tenantId and claims to create the provisioning request
        ProvisionUserRequest createRequest = CreateProvisionUserRequest(tenantId, validatedClaims);

        // Call the service to actually create the account.
        // Maybe this calls a database, or something else 
        var identityResult = createUserService.GetOrCreateAccount(createRequest);

        // Return the user
        return identityResult;
    }

    // Helper methods (just stubs)
    private Claim[]? GetClaimValues(ExternalLoginInfo loginInfo) => null;
    private Claim[]? ValidateClaims(Claim[]? claims) => claims;
    private Guid GetTenantId(Claim[]? claims) => Guid.NewGuid();
    private ProvisionUserRequest CreateProvisionUserRequest(Guid employerId, Claim[]? claims) => new();
}

// Helper types/services
public record ExternalLoginInfo;
public record ProvisionUserRequest;
public record UserAccount;

public class CreateUserService
{
    public UserAccount GetOrCreateAccount(ProvisionUserRequest request) => new();
}