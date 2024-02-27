using Microsoft.Extensions.DependencyInjection;

namespace Xelit3.Playground.Dumbain;

public static class Configuration
{
    public static IServiceCollection AddCommandHandler<THandler, TCommand>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        services.AddTransient<ICommandHandler<TCommand>, THandler>();

        return services;
    }

    public static IServiceCollection AddCommandHandler<THandler, TCommand, TResult>(this IServiceCollection services)
        where THandler : class, ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        services.AddTransient<ICommandHandler<TCommand, TResult>, THandler>();

        return services;
    }

    public static IServiceCollection AddQueryHandler<THandler, TQuery, TResult>(this IServiceCollection services)
        where THandler : class, IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        services.AddTransient<IQueryHandler<TQuery, TResult>, THandler>();

        return services;
    }
}
