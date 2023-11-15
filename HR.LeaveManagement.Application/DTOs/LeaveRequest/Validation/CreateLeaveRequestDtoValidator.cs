using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validation;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        Include(new ILeaveRequestDtoValidator(leaveTypeRepository));
    }
}