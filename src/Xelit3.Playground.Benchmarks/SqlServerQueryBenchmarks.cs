using BenchmarkDotNet.Attributes;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Dtos;
using Xelit3.Tests.Model.Views;

namespace Xelit3.Playground.Benchmarks;


[ShortRunJob]
[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerQueryBenchmarks
{

    [Params(100, 1000)]
    public int PageSize { get; set; }


    #region Single entity, paginated

    [Benchmark(Description = "EFCore - Retrieving paginated rows")]
    public void RetrievePaginatedRows()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows without tracking")]
    public void RetrievePaginatedRowsWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .AsNoTracking()
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows using a DTO projection")]
    public void RetrievePaginatedRowsUsingDtoProjection()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Select(x => new PersonDto
            {
                Id = x.Id,
                OriginId = x.OriginId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                Bio = x.Bio
            })
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows using FromSqlRaw/FromSqlInterpolated method to execute a SQL query")]
    public void RetrievePaginatedRowsUsingFromSqlRaw()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .FromSqlInterpolated
            (
                $"SELECT TOP ({PageSize}) [Id],[OriginId],[Name],[Surname],[BirthDate],[Bio],[Email],[PhoneNumber] FROM [dbo].[Persons_Guid]"
            )
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows using a View mapped/executed from EFCore")]
    public void RetrievePaginatedRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.PersonSimpleQuery
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows using a Store Procedure from EFCore")]
    public void RetrievePaginatedRowsUsingStoreProcedureFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
             .FromSqlInterpolated
            (
                $"[dbo].[GetPersons] {PageSize}"
            )
            .ToList();
    }

    [Benchmark(Description = "Dapper - Retrieving paginated rows using SQL query with Dapper")]
    public void RetrievePaginatedRowsUsingSqlQueryWithDapper()
    {
        var sql = $@"
            SELECT top ({PageSize})
                [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
            FROM [dbo].[Persons_Guid]
            ";

        using var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString);

        var persons = connection.Query<PersonSimpleView>(sql).ToList();
    }

    #endregion


    #region Single entity, paginated with joining tables, paginated

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables")]
    public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables using AsNoTracking()")]
    public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables using AsSplitQuery()")]
    public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables using AsSplitQuery() and AsNoTracking()")]
    public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTrackingAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables using SQL Select projection")]
    public void RetrievePaginatedRowsWithNestedEntitiesUsingProjectionFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .Select(x => new PersonDto
            {
                Id = x.Id,
                OriginId = x.OriginId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                Bio = x.Bio,
                Addresses = x.Addresses.Select(y => new AddressDto { Id = y.Id, CityId = y.CityId, Line = y.Line, Sequence = y.Sequence }),
                Posts = x.Posts.Select(y => new PostDto { Id = y.Id, Text = y.Text, Title = y.Title })
            })
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "EFCore - Retrieving paginated rows joining tables using a View mapped/executed from EFCore")]
    public void RetrievePaginatedRowsWithJoinedEntitiesUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.PersonFullQuery
            .Take(PageSize)
            .ToList();
    }

    [Benchmark(Description = "Dapper - Retrieving paginated rows joining tables using SQL query with Dapper")]
    public void RetrievePaginatedRowsWithJoinedEntitiesUsingDapperQuery()
    {
        var sql = $@"
                SELECT top ({PageSize})
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


    #region Single entity, one element with joining tables

    [Benchmark(Description = "EFCore - Retrieving single entity with joining tables using LINQ FirstAsync")]
    public async Task RetrieveFirstRowUsingLinq()
    {
        var data = await SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .FirstAsync();
    }

    [Benchmark(Description = "EFCore - Retrieving single element with joining tables using AsNoTracking()")]
    public async Task RetrieveFirstRowUsingLinqAndAsNoTracking()
    {
        var data = await SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .FirstAsync();
    }

    [Benchmark(Description = "EFCore - Retrieving single element with joining tables using AsSplitQuer()")]
    public async Task RetrieveFirstRowUsingLinqAndSplitQueries()
    {
        var data = await SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .FirstAsync();
    }

    [Benchmark(Description = "EFCore - Retrieving single element with joining tables using AsNoTracking() and AsSplitQuery()")]
    public async Task RetrieveFirstRowUsingLinqAndAsNoTrackingAndSplitQueries()
    {
        var data = await SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .FirstAsync();
    }

    [Benchmark(Description = "EFCore - Retrieving single element with joining tables using explicit loading")]
    public async Task RetrieveFirstRowUsingLinqAndExplicitLoading()
    {
        var context = SqlServerDbTestDataContextHelper.New.DbContext;
        var data = await context.Persons.FirstAsync();

        context.Entry(data).Collection(x => x.Addresses).Load();
        context.Entry(data).Collection(x => x.Posts).Load();
    }

    [Benchmark(Description = "EFCore - Retrieving single element with joining tables using LINQ Select projection")]
    public async Task RetrieveFilteredIdRowWithJoinedEntitiesUsingProjectionFromEFCore()
    {
        var id = SqlServerDbTestDataContextHelper.Instance.RandomPersonGuid!.Id;
        var data = await SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .Select(x => new PersonDto
            {
                Id = x.Id,
                OriginId = x.OriginId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                BirthDate = x.BirthDate,
                Bio = x.Bio,
                Addresses = x.Addresses.Select(y => new AddressDto { Id = y.Id, CityId = y.CityId, Line = y.Line, Sequence = y.Sequence }),
                Posts = x.Posts.Select(y => new PostDto { Id = y.Id, Text = y.Text, Title = y.Title })
            })
            .FirstAsync(x => x.Id == id);
    }

    [Benchmark(Description = "Dapper - Retrieving single element with joining tables using raw SQL multi-query with Dapper")]
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
