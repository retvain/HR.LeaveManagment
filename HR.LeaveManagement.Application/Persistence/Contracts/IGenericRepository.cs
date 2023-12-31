using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : BaseDomainEntity
{
    Task<T?> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exists(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task Delete(T entity);
    Task<T> GetByIdAsync(int id);
}