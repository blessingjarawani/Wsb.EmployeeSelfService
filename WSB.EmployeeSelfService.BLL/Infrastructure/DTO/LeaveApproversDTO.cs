using System;
using System.Collections.Generic;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.DTO
{
    public class LeaveApproversDTO
    {
        public int UserId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public LeaveApprovalLevel LeaveApprovalLevel { get; set; }

    }
}
