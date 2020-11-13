using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Process
{
    public class LeaveApplicationProcess : LeaveBaseProcess, ILeaveApplicationProcess
    {
        public LeaveApplicationProcess(ILeaveApplicationRepo leaveApplicationRepo) : base(leaveApplicationRepo)
        {

        }

        public async Task<LeaveApplicationDTO> AddLeave(AddLeaveApplicationCommand addLeaveApplicationCommand)
        {
           return await _leaveApplicationRepo.AddOrUpdateLeave(addLeaveApplicationCommand);
        }

        protected override Task GetApprovers()
        {
            return base.GetApprovers();
        }


        protected override Task<bool> SendNotification()
        {
            return base.SendNotification();
        }

        protected override Task UpdateStatus()
        {
            return base.UpdateStatus();
        }
    }
}
