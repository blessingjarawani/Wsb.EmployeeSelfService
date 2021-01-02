using System;
using System.Collections.Generic;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string EmpCode { get; set; }

        public string Email { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }

        public string AccNumber { get; set; }

        public string MedicalScheme { get; set; }

        public string MedicalRefNo { get; set; }
        public string LastName { get; set; }


        public string FirstName { get; set; }


        public string CompanyName { get; set; }


        public string Department { get; set; }
        public string Position { get; set; }

        public string EmployeeStatus { get; set; }

        public string Gender { get; set; }

        
    }
}
