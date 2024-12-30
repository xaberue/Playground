namespace Xelit3.Playground.ResultPattern;

public static class Helper
{

    /// <summary>
    /// Creates a new instance of UserProvisioningService, everything a mock
    /// </summary>
    /// <returns></returns>
    public static UserProvisioningService GetSampleService()
        => new UserProvisioningService(new CreateUserService());

}
