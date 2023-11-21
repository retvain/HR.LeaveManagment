using AutoMapper;
using FluentValidation.Results;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var response = new BaseCommandResponse();
        
        ValidationResult validationResult;
        if (request.LeaveAllocationDto != null)
        {
            validationResult = await validator.ValidateAsync(request.LeaveAllocationDto, cancellationToken);   
        }
        else
        {
            throw new Exception("LeaveAllocationDto is empty");
        }

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            return response;
        }
        
        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

        response.Success = true;
        response.Message = "Creation Success";
        response.Id = leaveAllocation.Id; 

        return response;
    }
}