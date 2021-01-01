using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.QueryHandlers
{
    public class GetEmployeeByEmployeeCodeHandler : IRequestHandler<GetEmployeeByEmployeeCodeQuery, IResponse<EmployeeDTO>>
    {
        private readonly IEmployeeRepo _employeeRepository;

        public GetEmployeeByEmployeeCodeHandler(IEmployeeRepo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IResponse<EmployeeDTO>> Handle(GetEmployeeByEmployeeCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeByEmpCode(request.EmployeeCode);
                return result!=null ? Response<EmployeeDTO>.CreateSuccess(result): 
                    Response<EmployeeDTO>.CreateFail("Employee Not Found");
            }
            catch (Exception ex)
            {
                return Response<EmployeeDTO>.CreateFail(ex.Message);
            }
        }
    }
}
