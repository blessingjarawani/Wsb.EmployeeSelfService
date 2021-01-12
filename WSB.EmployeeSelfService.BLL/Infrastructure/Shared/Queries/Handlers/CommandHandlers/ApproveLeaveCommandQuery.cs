using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.CommandHandlers
{
    public class ApproveLeaveCommandQuery : IRequest<IBaseResponse>
    {
        public int Id { get; set; }
        public int Status{ get; set; }

        public bool IsValid => Id > 0 && Status != ((int)LeaveStatus.InProgress);
    }
}
