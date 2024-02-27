namespace Xelit3.Playground.Dumbain;

public interface ICommand { }

public interface ICommand<TResult> { }

public interface IQuery<TResult> { }


public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task InvokeAsync(TCommand command);
}

public interface ICommandHandler<TCommand,  TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> InvokeAsync(TCommand command);
}

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Task<TResult> InvokeAsync(TQuery query);
}

