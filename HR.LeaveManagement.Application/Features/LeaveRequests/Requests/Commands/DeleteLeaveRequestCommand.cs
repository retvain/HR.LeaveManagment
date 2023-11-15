using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;

public class DeleteLeaveRequestCommand : IRequest
{
    public int Id { get; set; }
}