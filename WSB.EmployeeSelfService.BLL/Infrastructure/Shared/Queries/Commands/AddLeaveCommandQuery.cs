using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Commands
{
    public class AddLeaveCommandQuery : IRequest<IBaseResponse>
    {
        public string EmpCode { get; set; }
        public string LeaveType { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public float DaysTaken { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(EmpCode) &&
             !string.IsNullOrWhiteSpace(LeaveType) && !string.IsNullOrWhiteSpace(Description) &&
             !string.IsNullOrWhiteSpace(Comment) && DaysTaken != 0 && !string.IsNullOrWhiteSpace(DateFrom)
             && !string.IsNullOrWhiteSpace(DateFrom);

    }
}
