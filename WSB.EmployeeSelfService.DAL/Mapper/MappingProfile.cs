using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.Domain.Entities;

namespace WSB.EmployeeSelfService.DAL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<LeaveApplication, LeaveApplicationDTO>();
            CreateMap<LeaveApprovers, LeaveApproversDTO>();
        }
    }
}
