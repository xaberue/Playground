using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Text;
using TickerQ.Utilities;
using TickerQ.Utilities.Base;

namespace Xelit3.Playground.Scheduling.TickerqDemo.Jobs;

public class NotificationJobs
{
    //private readonly IEmailService _emailService;
    private readonly ILogger<NotificationJobs> _logger;
    private readonly AppDbContext _dbContext;

    public NotificationJobs(
        //IEmailService emailService,
        ILogger<NotificationJobs> logger,
        AppDbContext dbContext)
    {
        //_emailService = emailService;
        _logger = logger;
        _dbContext = dbContext;
    }

    [TickerFunction("SendWelcomeEmail")]
    public async Task SendWelcomeEmail(
        TickerFunctionContext context,
        CancellationToken cancellationToken)
    {
        var request = await TickerRequestProvider.GetRequestAsync<WelcomeEmailRequest>(
            context,
            cancellationToken
        );

        try
        {
            //await _emailService.SendAsync(
            //    to: request.Email,
            //    subject: "Welcome!",
            //    body: $"Hello {request.Name}, welcome to our platform!",
            //    cancellationToken
            //);

            _logger.LogInformation("Welcome email sent to {Email}", request.Email);
        }
        catch (SmtpException ex)
        {
            _logger.LogError(ex, "Failed to send welcome email to {Email}", request.Email);
            throw; // Retry on SMTP errors
        }
    }

    [TickerFunction("SendDailyDigest", cronExpression: "0 0 9 * * *")]
    public async Task SendDailyDigest(TickerFunctionContext context, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting daily digest job");

        var users = await _dbContext.Users.ToListAsync(cancellationToken);
        
        foreach (var user in users)
        {
            try
            {
                var notifications = await _dbContext.Notifications
                    .Where(n => n.UserId == user.Id
                        && n.CreatedAt >= DateTime.UtcNow.AddDays(-1))
                    .ToListAsync(cancellationToken);

                if (notifications.Any())
                {
                    //await _emailService.SendAsync(
                    //    to: user.Email,
                    //    subject: "Daily Digest",
                    //    body: FormatDigest(notifications),
                    //    cancellationToken
                    //);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send digest to {Email}", user.Email);
                // Continue with other users
            }
        }

        _logger.LogInformation("Daily digest job completed");
    }

    [TickerFunction("CleanupOldNotifications", cronExpression: "0 0 0 * * *")]
    public async Task CleanupOldNotifications(TickerFunctionContext context, CancellationToken cancellationToken)
    {
        var cutoffDate = DateTime.UtcNow.AddDays(-30);

        var oldNotifications = await _dbContext.Notifications
            .Where(n => n.CreatedAt < cutoffDate)
            .ToListAsync(cancellationToken);

        _dbContext.Notifications.RemoveRange(oldNotifications);
        await _dbContext.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Cleaned up {Count} old notifications", oldNotifications.Count);
    }

    private string FormatDigest(List<Notification> notifications)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Your daily digest:");
        foreach (var notification in notifications)
        {
            sb.AppendLine($"- {notification.Message}");
        }
        return sb.ToString();
    }
}