using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Dtos;
using Xelit3.Tests.Model.Views;

namespace Xelit3.Playground.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{
    #region Single entity, limited rows

    [Benchmark]
    public void RetrieveMultipleLimitedRowsWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultipleLimitedRowsWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsUsingDapperQuery()
    {
        var sql = $@"
            SELECT top ({SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve})
             [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
            FROM [dbo].[Persons_Guid]
            ";

        using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
        {
            var persons = connection.Query<PersonSimpleView>(sql).ToList();
        }
    }

    #endregion


    #region Single entity, all data

    [Benchmark]
    public void RetrieveAllRowsUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsUsingDapperQuery()
    {
        var sql = @"
            SELECT
             [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
            FROM [dbo].[Persons_Guid]
            ";

        using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
        {
            var persons = connection.Query<PersonSimpleView>(sql).ToList();
        }
    }

    #endregion


    #region Joining tables, limited rows

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithJoinedEntitiesUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveLimitedRowsWithJoinedEntitiesUsingDapperQuery()
    {
        var sql = $@"
            SELECT top ({SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve})
                persons.[Id] as [PersonId], persons.[OriginId], persons.[Name], persons.[Surname], persons.[BirthDate], persons.[Bio], persons.[Email], persons.[PhoneNumber],
                addresses.[Id] as [AddressId], addresses.[CityId], addresses.[Line], addresses.[Sequence],
                posts.[Id] as [PostId], posts.[Text], posts.[Title]
            FROM [dbo].[Persons_Guid] persons
                join [dbo].[Addresses_Guid] addresses on persons.Id = addresses.PersonId
                join [dbo].[Posts_Guid] posts on persons.Id = posts.AuthorId
            ";

        using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
        {
            var persons = connection.Query<PersonFullView>(sql).ToList();
        }
    }

    #endregion


    #region Joining tables, all data       

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQueryWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllWithJoinedEntitiesRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .ToList();
    }

    [Benchmark]
    public void RetrieveAllRowsWithJoinedEntitiesUsingDapperQuery()
    {
        var sql = @"
            SELECT 
            	persons.[Id] as [PersonId], persons.[OriginId], persons.[Name], persons.[Surname], persons.[BirthDate], persons.[Bio], persons.[Email], persons.[PhoneNumber],
             addresses.[Id] as [AddressId], addresses.[CityId], addresses.[Line], addresses.[Sequence],
             posts.[Id] as [PostId], posts.[Text], posts.[Title]
            FROM [dbo].[Persons_Guid] persons
             join [dbo].[Addresses_Guid] addresses on persons.Id = addresses.PersonId
             join [dbo].[Posts_Guid] posts on persons.Id = posts.AuthorId
            ";

        using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
        {
            var persons = connection.Query<PersonFullView>(sql).ToList();
        }
    }

    #endregion


    #region Single entity, one element with nested tables

    [Benchmark]
    public void RetrieveFirstRowUsingLinq()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    [Benchmark]
    public void RetrieveFirstRowUsingLinqAndSplitQueries()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    [Benchmark]
    public void RetrieveFirstRowUsingLinqAndExplicitLoading()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons.First();

        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();
    }

    [Benchmark]
    public async Task RetrieveFilteredIdRowWithJoinedEntitiesUsingDapperQuery()
    {
        var id = SqlServerDbTestDataContextHelper.Instance.RandomPersonGuid!.Id;
        var sql = $@"
            SELECT [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber] FROM [dbo].[Persons_Guid] WHERE Id = @PersonId;

            SELECT [Id], [CityId], [Line], [Sequence] FROM [dbo].[Addresses_Guid] WHERE [PersonId] = @PersonId;

            SELECT [Id], [Title], [Text] FROM [dbo].[Posts_Guid] WHERE [AuthorId] = @PersonId
            ";

        using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
        {
            using (var multiQuery = await connection.QueryMultipleAsync(sql, new { PersonId = id }))
            {
                var person = (await multiQuery.ReadAsync<PersonDto>()).First();
                var addresses = (await multiQuery.ReadAsync<AddressDto>()).ToList();
                var posts = (await multiQuery.ReadAsync<PostDto>()).ToList();

                person.Posts = posts;
                person.Addresses = addresses;
            }
        }
    }

    #endregion

}
