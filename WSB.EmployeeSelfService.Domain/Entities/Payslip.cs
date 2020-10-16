using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public class Payslip : BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public string Path { get; set; }
        public DateTime PayDate { get; set; }
    }
}
