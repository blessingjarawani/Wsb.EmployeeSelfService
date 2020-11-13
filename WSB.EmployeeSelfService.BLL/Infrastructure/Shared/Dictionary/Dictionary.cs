using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary
{
    public static class Dictionary
    {

        public enum Position
        {
            Employee = 0,
            Supervisor = 1,
            Manager = 2,
        }

        public enum LeaveApprovalLevel
        {
            Default = 0,
            First = 1,
            Second = 2,
            Third = 3
        }

        public enum EmployeeStatus
        {
            [Display(Name = "Permanent")]
            Permanent = 0,
            [Display(Name = "Contract")]
            Contract = 1,
            [Display(Name = "Probation")]
            Probation = 2,
            [Display(Name = "EndContract")]
            EndContract = 3
        }

        public enum Company
        {
            [Display(Name = "WSB")]
            WSB = 0,
            [Display(Name = "University of Zimbabawe")]
            UZ = 1,
        }

        public enum Gender
        {
            [Display(Name = "Male")]
            Male = 0,
            [Display(Name = "Female")]
            Female = 1
        }
        public enum LeaveType
        {
            [Display(Name = "Annual")]
            Annual = 0,
            [Display(Name = "Sick")]
            Sick = 1,
            [Display(Name = "Vacation")]
            Vacation = 2,
            [Display(Name = "Maternity")]
            Maternity = 3,
            [Display(Name = "Paternity")]
            Paternity = 4
        }
        public enum LeaveStatus
        {
            [Display(Name = "Cancelled")]
            Cancelled = -2,
            [Display(Name = "Rejected")]
            Rejected = -1,
            [Display(Name = "In Progress")]
            InProgress = 0,
            [Display(Name = "Waiting For Final Approval")]
            PendingFinalApproval = 1,
            [Display(Name = "Approved")]
            Approved = 2

        }
    }
}
