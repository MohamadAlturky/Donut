namespace Donut.SharedKernel.Repositories;

public interface IRepository<T>
{
    T Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
