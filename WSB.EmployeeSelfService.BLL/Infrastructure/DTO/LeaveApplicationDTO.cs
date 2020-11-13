using System;
using System.Collections.Generic;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.DTO
{
    public class LeaveApplicationDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public LeaveType LeaveType { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public float DaysTaken { get; set; }
        public LeaveStatus LeaveStatus { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}