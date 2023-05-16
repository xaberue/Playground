using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{

    [Benchmark]
    public void RetrieveMultilpeRowsWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithCartesianValues()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
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
