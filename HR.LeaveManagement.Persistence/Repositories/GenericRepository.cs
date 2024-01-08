using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseDomainEntity
{
    private readonly LeaveManagementDbContext _dbContext;

    public GenericRepository(LeaveManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T?> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public Task<IReadOnlyList<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        
        return entity != null;
    }

    public async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}