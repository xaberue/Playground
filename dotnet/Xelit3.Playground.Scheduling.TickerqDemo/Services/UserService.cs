using TickerQ.Utilities;
using TickerQ.Utilities.Entities;
using TickerQ.Utilities.Interfaces.Managers;

namespace Xelit3.Playground.Scheduling.TickerqDemo.Services;

public class UserService
{
    private readonly AppDbContext _context;
    private readonly ITimeTickerManager<TimeTickerEntity> _timeTickerManager;

    public UserService(
        AppDbContext context,
        ITimeTickerManager<TimeTickerEntity> timeTickerManager)
    {
        _context = context;
        _timeTickerManager = timeTickerManager;
    }

    public async Task<User> RegisterUserAsync(string email, string name)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Name = name,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Schedule welcome email
        await _timeTickerManager.AddAsync(new TimeTickerEntity
        {
            Function = "SendWelcomeEmail",
            ExecutionTime = DateTime.UtcNow.AddMinutes(5),
            Request = TickerHelper.CreateTickerRequest(new WelcomeEmailRequest
            {
                Email = email,
                Name = name,
                UserId = user.Id
            }),
            Description = $"Welcome email for {email}",
            Retries = 3,
            RetryIntervals = new[] { 60, 300, 900 } // Exponential backoff
        });

        return user;
    }
}