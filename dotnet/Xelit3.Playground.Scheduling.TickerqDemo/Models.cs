namespace Xelit3.Playground.Scheduling.TickerqDemo;


public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}


public class WelcomeEmailRequest
{
    public string Email { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
}