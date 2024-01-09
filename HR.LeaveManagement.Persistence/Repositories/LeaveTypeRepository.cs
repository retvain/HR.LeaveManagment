using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;
    
    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<LeaveAllocation?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<LeaveAllocation>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> Add(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(LeaveAllocation entity)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        throw new NotImplementedException();
    }
}