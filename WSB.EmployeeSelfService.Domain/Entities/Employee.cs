using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(8)]
        public string Empcode { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public Company Company { get; set; }

        [MaxLength(50)]
        public string Department { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string BankName { get; set; }

        [MaxLength(50)]
        public string Branch { get; set; }

        [MaxLength(50)]
        public string AccountNumber { get; set; }

        [MaxLength(50)]
        public string MedicalScheme { get; set; }

        [MaxLength(50)]
        public string AccNumber { get; set; }

        [MaxLength(50)]
        public string MedicalRefNo { get; set; }
        public Position Position { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        public Gender Gender { get; set; }

        public ICollection<LeaveApplication> LeaveApplications { get; set; }
        public ICollection<Payslip> Payslips { get; set; }
        public ICollection<LeaveApprovers> LeaveApprovers { get; set; }
    }
}
