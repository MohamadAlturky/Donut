using Donut.SharedKernel.Tabels;
using System.Data;
using Dapper;
using Donut.Core.DatabaseConnection;
using Donut.Core.Repositories;

namespace Donut.Repositories;
public interface IPersonRepository: IRepository<Person>
{
}
public class PersonRepository: IPersonRepository
{

    private readonly IDbConnectionFactory _factory;

    public PersonRepository(IDbConnectionFactory factory)
    {
        _factory=factory;
    }
    public async Task<Person> Add(Person entity)
    {
         using (var connection = _factory.CreateConnection())
         {
           
           var sql = "INSERT INTO Persons ([Name], [Age], [Wifes], [Char], [Alive], [Importance], [NonImportance], [Year], [DateOfBirth]) VALUES (@Name, @Age, @Wifes, @Char, @Alive, @Importance, @NonImportance, @Year, @DateOfBirth); SELECT CAST(SCOPE_IDENTITY() AS int);";
           var id = await connection.ExecuteScalarAsync<int>(sql, entity);
           entity.Id = id; // Assuming Person has an Id property
           return entity;
         }
    }
    public async Task<Person> AddTransactional(Person entity, IDbConnection connection, IDbTransaction transaction)
    {
        var sql = "INSERT INTO Persons ([Name], [Age], [Wifes], [Char], [Alive], [Importance], [NonImportance], [Year], [DateOfBirth]) VALUES (@Name, @Age, @Wifes, @Char, @Alive, @Importance, @NonImportance, @Year, @DateOfBirth); SELECT CAST(SCOPE_IDENTITY() AS int);";
        var id = await connection.ExecuteScalarAsync<int>(sql, entity, transaction);
        entity.Id = id; // Assuming Person has an Id property
        return entity;
    }
    public async Task Update(Person entity)
    {
         using (var connection = _factory.CreateConnection())
         {
           
           var sql = "UPDATE Person SET Name = @Name, Age = @Age, Wifes = @Wifes, Char = @Char, Alive = @Alive, Importance = @Importance, NonImportance = @NonImportance, Year = @Year, DateOfBirth = @DateOfBirth WHERE Id = @Id;";
           await connection.ExecuteAsync(sql, entity);
         }
    }
    public async Task UpdateTransactional(Person entity, IDbConnection connection, IDbTransaction transaction)
    {
        var sql = "UPDATE Person SET Name = @Name, Age = @Age, Wifes = @Wifes, Char = @Char, Alive = @Alive, Importance = @Importance, NonImportance = @NonImportance, Year = @Year, DateOfBirth = @DateOfBirth WHERE Id = @Id;";
        await connection.ExecuteAsync(sql, entity, transaction);
    }
    public async Task Delete(Person entity)
    {
         using (var connection = _factory.CreateConnection())
         {
            var sql = "DELETE FROM Person WHERE Id = @Id;";
            await connection.ExecuteAsync(sql, entity);
         }
    }
    public async Task DeleteTransactional(Person entity, IDbConnection connection, IDbTransaction transaction)
    {
         var sql = "DELETE FROM Person WHERE Id = @Id;";
         await connection.ExecuteAsync(sql, entity, transaction);
    }
}
