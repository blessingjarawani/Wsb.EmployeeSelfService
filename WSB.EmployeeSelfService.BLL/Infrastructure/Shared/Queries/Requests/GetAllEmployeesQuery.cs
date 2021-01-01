using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests
{
    public class GetAllEmployeesQuery : IRequest<IResponse<IEnumerable<EmployeeDTO>>>
    {
    }
}
