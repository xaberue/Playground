using Microsoft.AspNetCore.Diagnostics;

namespace Xelit3.Playground.API.Minimal.Rest;

internal static class GlobalExceptionHandler
{
    internal static void UseUnhandledExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async ctx =>
            {
                ctx.Response.StatusCode = 500;
                ctx.Response.ContentType = "application/json";

                var ctxFeature = ctx.Features.Get<IExceptionHandlerFeature>();

                if (ctxFeature is not null)
                {
                    await Console.Out.WriteLineAsync($"Error: {ctxFeature.Error}");

                    await ctx.Response.WriteAsJsonAsync(new
                    {
                        ctx.Response.StatusCode,
                        Message = "Internal Server Error"
                    });
                }
            });
        });
    }
}
