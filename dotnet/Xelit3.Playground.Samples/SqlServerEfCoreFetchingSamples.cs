using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.Samples;

public static class SqlServerEfCoreFetchingSamples
{

    public static void Run()
    {
        var multipleData = Enumerable.Empty<Person<int>>();
        Person<int> singleElement = default;

        // Multiple rows sample
        //1. Run a normal execution including more than one nested collection, with and without traking
        multipleData = RetrieveMultilpeRows();
        multipleData = RetrieveMultilpeRowsWithoutTracking();
        //2. Now use AsSplitQuery to see how queries are now splited avoiding cartesian values
        multipleData = RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery();

        // Single element sample
        //1. Run a normal execution including more than one nested collection, with and without traking
        singleElement = RetrieveSingleElementWithCartesianValues();
        //2. Now use AsSplitQuery to see how queries are now splited avoiding cartesian values
        singleElement = RetrieveSingleElementWithoutCartesianValues_SplitQuery();
        //3. Now use splicit loading to see the same but with even better performance
        singleElement = RetrieveSingleElementWithoutCartesianValues_ExplicitLoading();
    }


    private static IEnumerable<Person<int>> RetrieveMultilpeRows()
    {
        return SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    private static IEnumerable<Person<int>> RetrieveMultilpeRowsWithoutTracking()
    {
        return SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    private static IEnumerable<Person<int>> RetrieveMultilpeRowsWithoutCartesianValues_SplitQuery()
    {
        return SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }


    private static Person<int> RetrieveSingleElementWithCartesianValues()
    {
        return SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .First();
    }

    private static Person<int> RetrieveSingleElementWithoutCartesianValues_SplitQuery()
    {
        return SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>()
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    private static Person<int> RetrieveSingleElementWithoutCartesianValues_ExplicitLoading()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Set<Person<int>>().First();

        //https://learn.microsoft.com/en-us/ef/core/querying/related-data/explicit

        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Query();
        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Query();

        
        //EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        //EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();


        ////This captures the query executed over SQL Server
        //EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Query().Load();
        //EFTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Query().Load();

        return data;
    }
}
