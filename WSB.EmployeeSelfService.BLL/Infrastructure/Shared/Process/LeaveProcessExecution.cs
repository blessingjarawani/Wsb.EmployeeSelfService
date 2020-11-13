using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Process
{
    public class LeaveProcessExecution : LeaveBaseProcess
    {
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
