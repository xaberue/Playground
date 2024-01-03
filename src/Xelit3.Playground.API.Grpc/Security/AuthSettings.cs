namespace Xelit3.Playground.API.Grpc.Security;

public record AuthSettings
{
    public string SecretKey { get; set; } = null!;
    public Double MinutesToExpire { get; internal set; } = 10;
    public String SiteName { get; internal set; } = "https://localhost:7066";
}