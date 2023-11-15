namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation;

public class CreateLeaveAllocationDto
{
    public int NumbersOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}