namespace Xelit3.Playground.API.Grpc.Security;

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

