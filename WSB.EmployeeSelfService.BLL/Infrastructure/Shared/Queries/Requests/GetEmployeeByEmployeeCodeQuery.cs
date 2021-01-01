using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests
{
    public class GetEmployeeByEmployeeCodeQuery : IRequest<IResponse<EmployeeDTO>>
    {
        public string EmployeeCode { get; set; }
    }
}
