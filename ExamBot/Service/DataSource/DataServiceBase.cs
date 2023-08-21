using System.Runtime.InteropServices.JavaScript;
using ExamBot.Domain.Entity;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;

namespace ExamBot.Service.DataSource;

public  class DataServiceBase<T>:IServiceBase<T> where T : ModelBase
{
    private readonly DbContext _dbContext;

    public DataServiceBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> Create(T data)
    {
        var entityEntry = await this._dbContext
            .Set<T>()
            .AddAsync(entity:data);

        await this._dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<T> Update(T data)
    {
        var entityEntry = this._dbContext
            .Set<T>()
            .Update(entity:data);

        await this._dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task<T> Delete(long Id)
    {
        var entityEntry = this._dbContext
            .Set<T>()
            .FirstOrDefault(x => x.Id == Id);

        if(entityEntry is not null)
            _dbContext.Remove(entityEntry);

        await this._dbContext.SaveChangesAsync();

        return entityEntry;
    }

    public async Task<T?> FindById(long Id)
    {
        return await this.GetAll().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public  IQueryable<T> GetAll()
    {
        return  this._dbContext.Set<T>();
    }
}