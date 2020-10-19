using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces
{
    public interface ILeaveApplicationRepo
    {
        Task<List<LeaveApplicationDTO>> GetActiveApplications();
        Task<LeaveApplicationDTO> AddOrUpdateLeave(AddLeaveApplicationCommand addLeaveApplicationCommand);
    }
}
