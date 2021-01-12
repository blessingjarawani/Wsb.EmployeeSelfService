using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.DTO
{
    public class UserDTO
    {
        public int ? EmployeeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string EmpCode { get; set; }
        public int? IsApprover { get; set; }
    }
}
