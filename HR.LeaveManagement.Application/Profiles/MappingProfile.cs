using AutoMapper;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    protected MappingProfile()
    {
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
    }
}