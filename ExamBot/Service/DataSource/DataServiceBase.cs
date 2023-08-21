using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamBot.Service.DataSource;

public abstract class DataServiceBase<T>:IServiceBase<T>
{
    private readonly DbContext _dbContext;

    public DataServiceBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<T> Create(T data)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T data)
    {
        throw new NotImplementedException();
    }

    public Task<T> Delete(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<T> FindById(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<T>> GetAll()
    {
        throw new NotImplementedException();
    }
}