using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Xelit3.Playground.ResultPattern;

public class UserProvisioningService(CreateUserService createUserService)
{
    public Result<UserAccount> ProvisionUser(ExternalLoginInfo info)
    {
        // 1. Try to get the initial claim results
        Result<Claim[]> claimsResult = GetClaimValues(info);

        return claimsResult.Switch(
            onSuccess: claims => // if the claims we retrieved successfully, run this function
            {
                // 2. Try to validate the claims
                Result<Claim[]> validatedClaimsResult = ValidateClaims(claims);
                return validatedClaimsResult.Switch(
                    onSuccess: validatedClaims =>  // validation was successful
                    {
                        // 3. Try to extract the tenant ID
                        Result<Guid> tenantIdResult = GetTenantId(claims);
                        return tenantIdResult.Switch(
                            onSuccess: tenantId => // extracted successfully
                            {
                                // 4. Create the ProvisionUserRequest object
                                Result<ProvisionUserRequest> createRequestResult =
                                    CreateProvisionUserRequest(tenantId, validatedClaims);
                                return createRequestResult.Switch<Result<UserAccount>>(
                                    onSuccess: createRequest => // created the request successfully
                                    {
                                        // 5. Try to create the account, and return the Result<UserAccount>
                                        return createUserService.GetOrCreateAccount(createRequest);
                                    },
                                    onFailure: ex => Result<UserAccount>.Fail(ex)); // Step 4 failed, return the error 
                            },
                            onFailure: ex => Result<UserAccount>.Fail(ex)); // Step 3 failed, return the error 

                    },
                    onFailure: ex => Result<UserAccount>.Fail(ex)); // Step 2 failed, return the error 
            },
            onFailure: ex => Result<UserAccount>.Fail(ex)); // Step 1 failed, return the error 
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