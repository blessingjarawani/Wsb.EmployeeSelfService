using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public LeaveApprovalLevel ? LeaveApprovalLevel { get; set; }

    }
}
