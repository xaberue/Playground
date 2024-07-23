using BenchmarkDotNet.Attributes;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerEfCoreFetchingDifferentPrimaryKeysBenchmarks
{

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromGuid()
    {
        var element = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons.Find(SqlServerDbTestDataContextHelper.Instance.RandomPersonGuid.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromInt()
    {
        var element = SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>().Find(SqlServerDbTestDataContextHelper.Instance.RandomPersonInt.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromLong()
    {
        var element = SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<long>>().Find(SqlServerDbTestDataContextHelper.Instance.RandomPersonLong.Id);

        return await Task.FromResult(true);
    }

}
