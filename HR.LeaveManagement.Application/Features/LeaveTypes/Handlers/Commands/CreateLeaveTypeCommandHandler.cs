using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validation;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        if (request.CreateLeaveTypeDto is null)
        {
            throw new Exception("empty CreateLeaveTypeDto in request");
        }

        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto, cancellationToken);
        var response = new BaseCommandResponse();

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

            return response;
        }

        var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

        leaveType = await _leaveTypeRepository.Add(leaveType);

        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = leaveType.Id;

        return response;
    }
}