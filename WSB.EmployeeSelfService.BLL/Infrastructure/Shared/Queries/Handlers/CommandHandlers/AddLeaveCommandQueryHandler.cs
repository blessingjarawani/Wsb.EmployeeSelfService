using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.CommandHandlers
{
    public class AddLeaveCommandQueryHandler : IRequestHandler<AddLeaveCommandQuery, IBaseResponse>
    {
        private readonly ILeaveApplicationRepo _repo;
        private readonly IEmployeeRepo _employeeRepo;

        public AddLeaveCommandQueryHandler(ILeaveApplicationRepo repo, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }
        public async Task<IBaseResponse> Handle(AddLeaveCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return BaseResponse.CreateFail("Invalid request");
                var employee = await _employeeRepo.GetEmployeeByEmpCode(request.EmpCode);
                if (employee == null)
                    return BaseResponse.CreateFail("Employee Not Found");
                var addCommand = CreateDTO(request, employee);
                var result = await _repo.AddOrUpdateLeave(addCommand);
                return result ? BaseResponse.CreateSuccess()
                    : BaseResponse.CreateFail("Failed to Save Leave");

            }
            catch (Exception ex)
            {
                return BaseResponse.CreateFail(ex.Message);
            }
        }

        private AddLeaveApplicationCommand CreateDTO(AddLeaveCommandQuery request, DTO.EmployeeDTO employee)
        {
            return new AddLeaveApplicationCommand
            {
                Comment = request.Comment,
                DateFrom = DateTime.Parse(request.DateFrom),
                DateTo = DateTime.Parse(request.DateTo),
                DaysTaken = request.DaysTaken,
                Description = request.Description,
                EmployeeId = employee.Id,
                LeaveStatus = LeaveStatus.InProgress,
                LeaveType = (LeaveType)Enum.Parse(typeof(LeaveType), request.LeaveType)
            };

        }
    }
}
