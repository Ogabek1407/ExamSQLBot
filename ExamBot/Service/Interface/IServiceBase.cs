namespace Interfaces;

public interface IServiceBase<T>
{
    Task<T> Create(T data);
    Task<T> Update(T data);
    Task<T> Delete(long Id);
    Task<T> FindById(long Id);
    Task<IQueryable<T>> GetAll();
}