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
        public string LeaveType { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public float DaysTaken { get; set; }
        public string LeaveStatus { get; set; }

        public string DateFromString => DateFrom.ToString("dd-MM-yyyy");
        public string DateToString => DateTo.ToString("dd-MM-yyyy");
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}