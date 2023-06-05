using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data.SqlClient;
using Xelit3.Playground.SqlServer;
using Xelit3.Tests.Model.Dtos;
using Xelit3.Tests.Model.Views;

namespace Xelit3.Playground.Samples;

public class SqlServerQuerySamples
{

    #region Single entity, limited rows
        
    public void RetrieveMultipleLimitedRowsWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveMultipleLimitedRowsWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsUsingProjectionFromEFCore()
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
                Bio = x.Bio
            })
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsUsingFromSqlInterpolatedFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .FromSqlInterpolated
            (
                $"SELECT TOP ({SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve}) [Id],[OriginId],[Name],[Surname],[BirthDate],[Bio],[Email],[PhoneNumber] FROM [dbo].[Persons_Guid]"
            )
            .ToList();
    }
        
    public void RetrieveLimitedRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
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
        
    public void RetrieveAllRowsUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .ToList();
    }
    
    public void RetrieveAllRowsUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .AsNoTracking()
            .ToList();
    }
    
    public void RetrieveAllRowsUsingProjectionFromEFCore()
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
                Bio = x.Bio
            })
            .ToList();
    }
    
    public void RetrieveAllRowsUsingFromSqlInterpolatedFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .FromSqlRaw
            (
                $"SELECT [Id],[OriginId],[Name],[Surname],[BirthDate],[Bio],[Email],[PhoneNumber] FROM [dbo].[Persons_Guid]"
            )
            .ToList();
    }
    
    public void RetrieveAllRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonSimpleQuery
            .ToList();
    }
    
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
        
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsWithNestedEntitiesUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsWithNestedEntitiesUsingProjectionFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
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
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
    public void RetrieveLimitedRowsWithJoinedEntitiesUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .Take(SqlServerDbTestDataContextHelper.Instance.RowsToRetrieve)
            .ToList();
    }
    
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
    
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .ToList();
    }
    
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .ToList();
    }
    
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQuery()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsSplitQuery()
            .ToList();
    }
    
    public void RetrieveAllWithNestedEntitiesRowsUsingLinqAndSplitQueryWithoutTracking()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
            .Include(x => x.Addresses)
            .Include(x => x.Posts)
            .AsNoTracking()
            .AsSplitQuery()
            .ToList();
    }
    
    public void RetrieveAllRowsWithNestedEntitiesUsingProjectionFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.Persons
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
            .ToList();
    }
        
    public void RetrieveAllWithJoinedEntitiesRowsUsingViewFromEFCore()
    {
        var data = SqlServerDbTestDataContextHelper.Instance.DbContext.PersonFullQuery
            .ToList();
    }
    
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
