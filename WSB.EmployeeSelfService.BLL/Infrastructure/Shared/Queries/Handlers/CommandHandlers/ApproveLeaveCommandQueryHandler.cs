using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.CommandHandlers
{
    public class ApproveLeaveCommandQueryHandler : IRequestHandler<ApproveLeaveCommandQuery, IBaseResponse>
    {
        private readonly ILeaveApplicationRepo _repo;

        public ApproveLeaveCommandQueryHandler(ILeaveApplicationRepo leaveApplicationRepo)
        {
            _repo = leaveApplicationRepo;
        }
        public async Task<IBaseResponse> Handle(ApproveLeaveCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!request.IsValid)
                    return BaseResponse.CreateFail("Invalid Request");
                var result = await _repo.UpdateStatus((LeaveStatus)request.Status, request.Id);
                return result ? BaseResponse.CreateSuccess() :BaseResponse.CreateFail("Failed To Update Leave Status");
            }
            catch (Exception ex)
            {

                return BaseResponse.CreateFail(ex.Message);
            }
        }
    }
}
