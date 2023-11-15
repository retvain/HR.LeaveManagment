using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validation;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateLeaveTypeDto is null)
        {
            throw new Exception("empty CreateLeaveTypeDto in request");
        }

        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto, cancellationToken);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

        leaveType = await _leaveTypeRepository.Add(leaveType);

        return leaveType.Id;
    }
}