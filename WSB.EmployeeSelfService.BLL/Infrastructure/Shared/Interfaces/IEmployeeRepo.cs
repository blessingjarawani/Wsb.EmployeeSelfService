using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces
{
   public interface IEmployeeRepo
    {
        Task<List<EmployeeDTO>> GetActiveEmployees();
        Task<EmployeeDTO> GetEmployeeByEmpCode(string empCode);
        Task<EmployeeDTO> GetEmployeeByID(int id);
    }
}
