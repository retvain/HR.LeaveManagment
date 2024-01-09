using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;
    
    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
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