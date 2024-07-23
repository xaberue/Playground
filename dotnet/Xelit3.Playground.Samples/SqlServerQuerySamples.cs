using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Dtos;
using Xelit3.Tests.Model.Views;

namespace Xelit3.Playground.Samples;

public class SqlServerQuerySamples
{
    public static async Task Run()
    {
        var samples = new SqlServerQuerySamples();

        //Execute and debug any of the below scenarios.

        try
        {
            //samples.RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithTracking();
            //samples.RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTracking();
            //samples.RetrievePaginatedRowsWithNestedEntitiesUsingLinqAndSplitQuery();
            //samples.RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTrackingAndSplitQuery();
            //samples.RetrievePaginatedRowsWithNestedEntitiesUsingProjectionFromEFCore();
            //samples.RetrievePaginatedRowsWithJoinedEntitiesUsingViewFromEFCore();
            //samples.RetrievePaginatedRowsWithJoinedEntitiesUsingDapperQuery();

            //samples.RetrievePaginatedRows();
            //samples.RetrievePaginatedRowsWithoutTracking();
            //samples.RetrievePaginatedRowsUsingDtoProjection();
            //samples.RetrievePaginatedRowsUsingFromSqlRaw();
            //samples.RetrievePaginatedRowsUsingViewFromEFCore();
            //samples.RetrievePaginatedRowsUsingStoreProcedureFromEFCore();
            //samples.RetrievePaginatedRowsUsingSqlQueryWithDapper();

            //samples.RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking();
            //samples.RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking();
            //samples.RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery();
            //samples.RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTrackingAndSplitQuery();
            //samples.RetrieveLimitedRowsWithNestedEntitiesUsingProjectionFromEFCore();
            //samples.RetrieveLimitedRowsWithJoinedEntitiesUsingViewFromEFCore();
            //samples.RetrieveLimitedRowsWithJoinedEntitiesUsingDapperQuery();

            //samples.RetrieveFirstRowUsingLinq();
            //samples.RetrieveFirstRowUsingLinqAndExplicitLoading();
            samples.RetrieveFilteredIdRowWithJoinedEntitiesUsingProjectionFromEFCore();
            //await samples.RetrieveFilteredIdRowWithJoinedEntitiesUsingDapperQuery();

        }
        catch (Exception ex)
        {
            throw;
        }
    }



    //#region Single entity, paginated with joining tables, paginated

    //public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithTracking()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
    //        .Include(x => x.Addresses)
    //        .Include(x => x.Posts)
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
    //        .Include(x => x.Addresses)
    //        .Include(x => x.Posts)
    //        .AsNoTracking()
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
    //        .Include(x => x.Addresses)
    //        .Include(x => x.Posts)
    //        .AsSplitQuery()
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithNestedEntitiesUsingLinqWithoutTrackingAndSplitQuery()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
    //        .Include(x => x.Addresses)
    //        .Include(x => x.Posts)
    //        .AsNoTracking()
    //        .AsSplitQuery()
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithNestedEntitiesUsingProjectionFromEFCore()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
    //        .Include(x => x.Addresses)
    //        .Include(x => x.Posts)
    //        .Select(x => new PersonDto
    //        {
    //            Id = x.Id,
    //            OriginId = x.OriginId,
    //            Name = x.Name,
    //            Surname = x.Surname,
    //            Email = x.Email,
    //            PhoneNumber = x.PhoneNumber,
    //            BirthDate = x.BirthDate,
    //            Bio = x.Bio,
    //            Addresses = x.Addresses.Select(y => new AddressDto { Id = y.Id, CityId = y.CityId, Line = y.Line, Sequence = y.Sequence }),
    //            Posts = x.Posts.Select(y => new PostDto { Id = y.Id, Text = y.Text, Title = y.Title })
    //        })
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithJoinedEntitiesUsingViewFromEFCore()
    //{
    //    var data = SqlServerDbTestDataContextHelper.New.DbContext.PersonFullQuery
    //        .Take(100)
    //        .ToList();
    //}

    //public void RetrievePaginatedRowsWithJoinedEntitiesUsingDapperQuery()
    //{
    //    var sql = $@"
    //            SELECT top ({100})
    //                persons.[Id] as [PersonId], persons.[OriginId], persons.[Name], persons.[Surname], persons.[BirthDate], persons.[Bio], persons.[Email], persons.[PhoneNumber],
    //                addresses.[Id] as [AddressId], addresses.[CityId], addresses.[Line], addresses.[Sequence],
    //                posts.[Id] as [PostId], posts.[Text], posts.[Title]
    //            FROM [dbo].[Persons_Guid] persons
    //                join [dbo].[Addresses_Guid] addresses on persons.Id = addresses.PersonId
    //                join [dbo].[Posts_Guid] posts on persons.Id = posts.AuthorId
    //            ";

    //    using (var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString))
    //    {
    //        var persons = connection.Query<PersonFullView>(sql).ToList();
    //    }
    //}

    //#endregion






    #region Single entity, limited rows

    public void RetrievePaginatedRows()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .Take(10)
            .ToList();
    }

    public void RetrievePaginatedRowsWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .AsNoTracking()
            .Take(10)
            .ToList();
    }

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
            .Take(10)
            .ToList();
    }

    public void RetrievePaginatedRowsUsingFromSqlRaw()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
            .FromSqlInterpolated
            (
                $"SELECT TOP ({10}) [Id],[OriginId],[Name],[Surname],[BirthDate],[Bio],[Email],[PhoneNumber] FROM [dbo].[Persons_Guid]"
            )
            .ToList();
    }

    public void RetrievePaginatedRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.PersonSimpleQuery
            .Take(10)
            .ToList();
    }

    public void RetrievePaginatedRowsUsingStoreProcedureFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.New.DbContext.Persons
             .FromSqlInterpolated
            (
                $"[dbo].[GetPersons] {10}"
            )
            .ToList();
    }

    public void RetrievePaginatedRowsUsingSqlQueryWithDapper()
    {
        var sql = $@"
            SELECT top ({10})
                [Id], [OriginId], [Name], [Surname], [BirthDate], [Bio], [Email], [PhoneNumber]
            FROM [dbo].[Persons_Guid]
            ";

        using var connection = new SqlConnection(SqlServerDbTestDataContextHelper.TestDbConnectionString);

        var persons = connection.Query<PersonSimpleView>(sql).ToList();
    }

    #endregion


    #region Joining tables, limited rows

    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTrackingAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithNestedEntitiesUsingProjectionFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
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
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithJoinedEntitiesUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .Take(10)
            .ToList();
    }

    public void RetrieveLimitedRowsWithJoinedEntitiesUsingDapperQuery()
    {
        var sql = $@"
                SELECT top ({10})
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

    public void RetrieveFirstRowUsingLinq()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .First();
    }

    public void RetrieveFirstRowUsingLinqAndSplitQueries()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .First();
    }

    public void RetrieveFirstRowUsingLinqAndExplicitLoading()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons.First();

        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Addresses).Load();
        SqlServerDbTestDataContextHelper.Instance.DbContext.Entry(data).Collection(x => x.Posts).Load();
    }

    public void RetrieveFilteredIdRowWithJoinedEntitiesUsingProjectionFromEFCore()
    {
        var id = SqlServerDbTestDataContextHelper.Instance.RandomPersonGuid!.Id;
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
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
            .First(x => x.Id == id);
    }

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
