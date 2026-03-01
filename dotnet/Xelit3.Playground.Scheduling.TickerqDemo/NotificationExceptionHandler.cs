namespace Xelit3.Playground.Scheduling.TickerqDemo;

using System.Net.Mail;
using TickerQ.Utilities.Enums;
// NotificationExceptionHandler.cs
using TickerQ.Utilities.Interfaces;

public class NotificationExceptionHandler : ITickerExceptionHandler
{
    private readonly ILogger<NotificationExceptionHandler> _logger;
    //private readonly IAlertService _alertService;

    public NotificationExceptionHandler(ILogger<NotificationExceptionHandler> logger
        //,IAlertService alertService
        )
    {
        _logger = logger;
        //_alertService = alertService;
    }

    public async Task HandleExceptionAsync(
        Exception exception,
        Guid tickerId,
        TickerType tickerType)
    {
        _logger.LogError(exception,
            "Job {TickerId} ({TickerType}) failed",
            tickerId, tickerType);

        // Send alert for critical failures
        if (exception is SmtpException)
        {
            //await _alertService.SendAlertAsync(
            //    "Email service failure",
            //    exception.ToString()
            //);
        }
    }

    public async Task HandleCanceledExceptionAsync(
        Exception exception,
        Guid tickerId,
        TickerType tickerType)
    {
        _logger.LogWarning(
            "Job {TickerId} ({TickerType}) was cancelled",
            tickerId, tickerType);
        await Task.CompletedTask;
    }
}