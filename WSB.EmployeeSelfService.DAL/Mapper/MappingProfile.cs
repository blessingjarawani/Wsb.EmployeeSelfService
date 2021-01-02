using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Extensions;
using WSB.EmployeeSelfService.Domain.Entities;

namespace WSB.EmployeeSelfService.DAL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ForMember
                (dest => dest.CompanyName, m => m.MapFrom(u => u.Company.DisplayName()))
                .ForMember
                 (dest => dest.Position, m => m.MapFrom(u => u.Position.DisplayName()))
                .ForMember
                 (dest => dest.Gender, m => m.MapFrom(u => u.Gender.DisplayName()))
                .ForMember
                 (dest => dest.EmployeeStatus, m => m.MapFrom(u => u.EmployeeStatus.DisplayName()));
            CreateMap<LeaveApplication, LeaveApplicationDTO>()
                .ForMember
                (dest => dest.LeaveStatus, m => m.MapFrom(u => u.LeaveStatus.DisplayName()))
                .ForMember
                (dest => dest.LeaveType, m => m.MapFrom(u => u.LeaveType.DisplayName()));
            CreateMap<LeaveApprovers, LeaveApproversDTO>();
        }
    }
}
