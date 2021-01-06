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
    public class GetEmployeeLeaveApplicationsQueryHandler : IRequestHandler<GetEmployeeLeaveApplicationsQuery, IResponse<List<LeaveApplicationDTO>>>
    {
        private readonly ILeaveApplicationRepo _repo;
        private readonly IEmployeeRepo _employeeRepo;

        public GetEmployeeLeaveApplicationsQueryHandler(ILeaveApplicationRepo repo, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }
        public async Task<IResponse<List<LeaveApplicationDTO>>> Handle(GetEmployeeLeaveApplicationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(request.EmpCode))
                {
                    var employee = await _employeeRepo.GetEmployeeByEmpCode(request.EmpCode);
                    if (employee == null)
                        return Response<List<LeaveApplicationDTO>>.CreateFail("Employee not found");
                    var leaveApplications = await _repo.GetEmployeeApplications(employee.Id);
                    return Response<List<LeaveApplicationDTO>>.CreateSuccess(leaveApplications);

                }
                return Response<List<LeaveApplicationDTO>>.CreateFail("Invalid Request EmpCode is required");
            }
            catch (Exception ex)
            {
                return Response<List<LeaveApplicationDTO>>.CreateFail(ex.Message);
            }
        }
    }
}
