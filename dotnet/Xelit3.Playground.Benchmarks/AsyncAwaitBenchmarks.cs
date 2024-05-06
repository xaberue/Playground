using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Dapper;
using System.Data.SqlClient;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.Benchmarks;

[MemoryDiagnoser(false)]
public class AsyncAwaitBenchmarks
{

    private readonly Consumer consumer = new Consumer();


    [Benchmark]
    public async Task<bool> ReturnFromTaskMethod()
    {
        return await ReturnTaskMethod();
    }

    [Benchmark]
    public async Task<bool> ReturnFromAwaitMethod()
    {
        return await ReturnAwaitMethod();
    }

    [Benchmark]
    public async Task<bool> ReturnFromAwaitValueTaskMethod()
    {
        return await ReturnAwaitValueTaskMethod();
    }

    [Benchmark]
    public async Task ReturnFromDbTaskAwaited()
    {
        (await InvokeDbQueryTaskAwaited()).Consume(consumer);
    }

    [Benchmark]
    public async ValueTask ReturnFromDbValueTaskAwaited()
    {
        (await InvokeDbQueryValueTaskAwaited()).Consume(consumer);
    }

    [Benchmark]
    public async Task ReturnFromDbTask()
    {
        (await InvokeDbQuery()).Consume(consumer);
    }

    private Task<bool> ReturnTaskMethod()
    {
        return Task.FromResult(true);
    }

    private async Task<bool> ReturnAwaitMethod()
    {
        return await Task.FromResult(true);
    }

    private async ValueTask<bool> ReturnAwaitValueTaskMethod()
    {
        return await ValueTask.FromResult(true);
    }

    private async Task<IEnumerable<User>> InvokeDbQueryTaskAwaited()
    {
        var queryString = @"SELECT * FROM [dbo].[Users]";

        using var db = new SqlConnection("Data Source=localhost;Initial Catalog=Training;Integrated Security=True");
        return await db.QueryAsync<User>(queryString);
    }

    private async ValueTask<IEnumerable<User>> InvokeDbQueryValueTaskAwaited()
    {
        var queryString = @"SELECT * FROM [dbo].[Users]";

        using var db = new SqlConnection("Data Source=localhost;Initial Catalog=Training;Integrated Security=True");
        return await db.QueryAsync<User>(queryString);
    }

    private Task<IEnumerable<User>> InvokeDbQuery()
    {
        var queryString = @"SELECT * FROM [dbo].[Users]";

        //Be careful, this connection is not disposed for testing purpose, never use in a real scenario
        var db = new SqlConnection("Data Source=localhost;Initial Catalog=Training;Integrated Security=True");
        return db.QueryAsync<User>(queryString);
    }

}
