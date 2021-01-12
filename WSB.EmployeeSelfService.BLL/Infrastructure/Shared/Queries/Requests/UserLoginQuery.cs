using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests
{
    public class UserLoginQuery : IRequest<IResponse<UserDTO>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
