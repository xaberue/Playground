using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Xelit3.Playground.ResultPattern;

public class UserProvisioningService
{
    private readonly CreateUserService _createUserService;

    public UserProvisioningService(CreateUserService createUserService)
    {
        _createUserService = createUserService;
    }

    public Result<UserAccount> ProvisionUser(ExternalLoginInfo info)
    {
        return
           from claims in GetClaimValues(info)
           from validatedClaims in ValidateClaims(claims)
           from tenantId in GetTenantId(validatedClaims)
           from createRequest in CreateProvisionUserRequest(tenantId, validatedClaims)
           from userAccount in _createUserService.GetOrCreateAccount(createRequest)
           select userAccount;
    }

    // Helper methods (just stubs)
    private Result<Claim[]> GetClaimValues(ExternalLoginInfo loginInfo) => Result<Claim[]>.Success(null!);
    private Result<Claim[]> ValidateClaims(Claim[]? claims) => Result<Claim[]>.Success(claims!);
    private Result<Guid> GetTenantId(Claim[]? claims) => Result<Guid>.Success(Guid.NewGuid());
    private Result<ProvisionUserRequest> CreateProvisionUserRequest(Guid employerId, Claim[]? claims) => Result<ProvisionUserRequest>.Success(new ProvisionUserRequest());
}

// Helper types/services
public record ExternalLoginInfo;
public record ProvisionUserRequest;
public record UserAccount;

public class CreateUserService
{
    public Result<UserAccount> GetOrCreateAccount(ProvisionUserRequest request) => Result<UserAccount>.Success(new UserAccount());
}
