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
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.QueryHandlers
{
    public class GetEmployeeLeaveToApproveQueryHandler : IRequestHandler<GetEmployeeLeaveToApproveQuery, IResponse<IList<LeaveApplicationDTO>>>
    {
        private readonly ILeaveApplicationRepo _repo;
        private readonly IEmployeeRepo _employeeRepo;

        public GetEmployeeLeaveToApproveQueryHandler(ILeaveApplicationRepo repo, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }
        public async Task<IResponse<IList<LeaveApplicationDTO>>> Handle(GetEmployeeLeaveToApproveQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(request.EmployeeCode))
                {
                    var employee = await _employeeRepo.GetEmployeeByEmpCode(request.EmployeeCode);
                    if (employee == null)
                        return Response<IList<LeaveApplicationDTO>>.CreateFail("Employee not found");
                    var leaveApplications = await _repo.GetEmployeeApplications(employee.Id, LeaveStatus.InProgress);
                    return Response<IList<LeaveApplicationDTO>>.CreateSuccess(leaveApplications);

                }
                return Response<IList<LeaveApplicationDTO>>.CreateFail("Invalid Request EmpCode is required");

            }
            catch (Exception ex)
            {
                return Response<IList<LeaveApplicationDTO>>.CreateFail(ex.Message);
            }
        }
    }
}
