using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validation;

public class CreateLeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
{
    public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        Include(new ILeaveRequestDtoValidator(leaveTypeRepository));
    }
}