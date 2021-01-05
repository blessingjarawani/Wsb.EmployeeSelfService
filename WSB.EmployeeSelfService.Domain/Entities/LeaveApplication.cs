using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public class LeaveApplication : BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Comment { get; set; }
        public float DaysTaken { get; set; }
        public LeaveStatus LeaveStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
      

    }
}
