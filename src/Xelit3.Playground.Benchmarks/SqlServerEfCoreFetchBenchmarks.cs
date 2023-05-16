using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerEfCoreFetchBenchmarks
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

    [Benchmark]
    public void RetrieveMultilpeRowsWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .AsNoTracking()
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithCartesianValues()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutCartesianValues_ExplicitLoading()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Set<Person<int>>().First();

        EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();
    }
}
