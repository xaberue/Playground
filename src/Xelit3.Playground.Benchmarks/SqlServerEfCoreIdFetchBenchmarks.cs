using BenchmarkDotNet.Attributes;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerEfCoreIdFetchBenchmarks
{

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromGuid()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Guid.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonGuid.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromInt()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonInt.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromLong()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Long.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonLong.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithTracking()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .Take(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutTracking()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .AsNoTracking()
            .Take(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithCartesianValues()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutCartesianValues_ExplicitLoading()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int.First();

        SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();
    }
}
