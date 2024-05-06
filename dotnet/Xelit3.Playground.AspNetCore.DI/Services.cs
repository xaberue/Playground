namespace Xelit3.Playground.AspNetCore.DI;


public interface IService 
{
    public Task<string> DoSomethingAsync();
}


public class ServiceImplementationA : IService
{
    public Task<string> DoSomethingAsync() => Task.FromResult("Hello there from Service A");
}

public class ServiceImplementationB : IService
{
    public Task<string> DoSomethingAsync() => Task.FromResult("Hello there from Service B");
}

public enum ServiceImplementation
{
    A,
    B
}

public delegate IService ServiceResolver(ServiceImplementation implementationType);