using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{

    [Benchmark]
    public void RetrieveMultipleRowsWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleRowsWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleWithNestedEntitiesRowsUsingLinq()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleWithNestedEntitiesRowsUsingLinqAndSplitQuery()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleWithNestedEntitiesUsingViewFromEFCore()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveFirstRowUsingLinq()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    [Benchmark]
    public void RetrieveFirstRowUsingLinqAndSplitQueries()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    [Benchmark]
    public void RetrieveFirstRowUsingLinqAndExplicitLoading()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons.First();

        EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();
    }
   
}
