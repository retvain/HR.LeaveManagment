using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validation;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        if (request.LeaveTypeDto == null) throw new Exception("LeaveTypeDto is null");
        
        var validator = new UpdateLeaveTypeDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto, cancellationToken);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }

        var leaveType = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);

        _mapper.Map(request.LeaveTypeDto, leaveType);

        if (leaveType != null) await _leaveTypeRepository.Update(leaveType);

        return Unit.Value;
    }
}