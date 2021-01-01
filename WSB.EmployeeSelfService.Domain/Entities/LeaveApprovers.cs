using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public class LeaveApprovers : BaseEntity
    {
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Users User { get; set; }
        

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
