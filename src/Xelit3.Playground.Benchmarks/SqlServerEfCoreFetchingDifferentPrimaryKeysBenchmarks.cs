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
        var element = EFTestDataContextHelper.Instance.DbContext.Persons.Find(EFTestDataContextHelper.Instance.RandomPersonGuid.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromInt()
    {
        var element = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>().Find(EFTestDataContextHelper.Instance.RandomPersonInt.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromLong()
    {
        var element = EFTestDataContextHelper.Instance.DbContext.Set<Person<long>>().Find(EFTestDataContextHelper.Instance.RandomPersonLong.Id);

        return await Task.FromResult(true);
    }

}
