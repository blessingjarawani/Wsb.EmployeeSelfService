using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.DAL.DataContexts;


namespace WSB.EmployeeSelfService.DAL.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly WSBEmployeeSelfServiceDataContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeRepo(WSBEmployeeSelfServiceDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetActiveEmployees()
        {
            var result = await _dbContext.Employees.Where(x => x.IsActive)?.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(result);
        }

        public async Task<EmployeeDTO> GetEmployeeByEmpCode(string empCode)
        {
            var result = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Empcode == empCode);
            return _mapper.Map<EmployeeDTO>(result);
        }
    }
}
