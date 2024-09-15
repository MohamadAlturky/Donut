using System.Data;

namespace Donut.SharedKernel.Repositories;

public interface IRepository<T>
{
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<T> AddTransactional(T entity, IDbConnection connection, IDbTransaction transaction);
    Task UpdateTransactional(T entity, IDbConnection connection, IDbTransaction transaction);
    Task DeleteTransactional(T entity, IDbConnection connection, IDbTransaction transaction);
}
