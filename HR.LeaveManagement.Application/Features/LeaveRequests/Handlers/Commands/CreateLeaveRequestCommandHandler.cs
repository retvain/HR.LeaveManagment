using AutoMapper;
using FluentValidation.Results;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validation;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);

        ValidationResult validationResult;
        if (request.LeaveRequestDto != null)
        {
            validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);
        }
        else
        {
            throw new Exception("LeaveRequestDto is empty");
        }

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        
        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);

        return leaveRequest.Id;
    }
}