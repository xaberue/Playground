namespace Xelit3.Playground.Dumbain;


//TODO: This interface should be registered within DI container

public interface ISampleService : 
    IQueryHandler<QuerySample, ResultTestObj[]>,
    ICommandHandler<CommandSample1>,
    ICommandHandler<CommandSample2, ResultTestObj>
{ }


internal class SampleService : ISampleService
{
    public Task<ResultTestObj[]> InvokeAsync(QuerySample query)
    {
        throw new NotImplementedException();
    }

    public Task InvokeAsync(CommandSample1 command)
    {
        throw new NotImplementedException();
    }

    public Task<ResultTestObj> InvokeAsync(CommandSample2 command)
    {
        throw new NotImplementedException();
    }
}



public class CommandSample1 : ICommand { }

public class CommandSample2 : ICommand<ResultTestObj> { }

public class QuerySample : IQuery<ResultTestObj[]> { }

public record ResultTestObj { }