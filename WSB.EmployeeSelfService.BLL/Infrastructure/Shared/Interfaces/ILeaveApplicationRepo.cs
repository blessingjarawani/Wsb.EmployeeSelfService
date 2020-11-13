using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces
{
    public interface ILeaveApplicationRepo
    {
        Task<List<LeaveApplicationDTO>> GetActiveApplications();
        Task<LeaveApplicationDTO> AddOrUpdateLeave(AddLeaveApplicationCommand addLeaveApplicationCommand);
        Task<List<LeaveApplicationDTO>> GetEmployeeApplications(int empCode);
        Task<List<LeaveApproversDTO>> GetEmployeeApprovers(string empCode);
        Task<bool> UpdateStatus(LeaveStatus leaveStatus, int leaveId);
    }
}
