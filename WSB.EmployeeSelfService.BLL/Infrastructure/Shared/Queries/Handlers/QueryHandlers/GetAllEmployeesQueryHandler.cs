using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.QueryHandlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IResponse<IEnumerable<EmployeeDTO>>>
    {
        private readonly IEmployeeRepo _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IResponse<IEnumerable<EmployeeDTO>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeRepository.GetActiveEmployees();
                return !(result?.Any() ?? false) ? Response<IEnumerable<EmployeeDTO>>.CreateFail("No Employees Found")
                     : Response<IEnumerable<EmployeeDTO>>.CreateSuccess(result);
            }
            catch (Exception ex)
            {

                return Response<IEnumerable<EmployeeDTO>>.CreateFail(ex.Message);
            }
        }
    }
}
