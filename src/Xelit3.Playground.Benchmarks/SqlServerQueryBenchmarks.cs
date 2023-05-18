using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{
    #region Single entity, limited rows

    [Benchmark]
    public void RetrieveMultipleLimitedRowsWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleLimitedRowsWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsUsingViewFromEFCore()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    #endregion


    #region Single entity, all data

    [Benchmark]
    public void RetrieveAllRowsUsingLinqWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsUsingLinqWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsUsingViewFromEFCore()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .ToList();
    }

    #endregion


    #region Joining tables, limited rows

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingViewFromEFCore()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .Take(EFTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    #endregion


    #region Joining tables, all data       

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQuery()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQueryWithoutTracking()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingViewFromEFCore()
    {
        var data = EFTestDataContextHelper.Instance.DbContext.PersonFullQuery            
            .ToList();
    }

    #endregion


    #region Single entity, one element with nested tables

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

    #endregion

}
