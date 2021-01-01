using System;
using System.Collections.Generic;
using System.Text;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Empcode { get; set; }


        public string LastName { get; set; }


        public string FirstName { get; set; }


        public string CompanyName { get; set; }


        public string Department { get; set; }
        public Position Position { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        public Gender Gender { get; set; }

        
    }
}
