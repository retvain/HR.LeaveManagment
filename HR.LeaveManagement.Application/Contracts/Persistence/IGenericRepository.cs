using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseDomainEntity
{
    Task<T?> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exists(int id);
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<T> GetByIdAsync(int id);
}