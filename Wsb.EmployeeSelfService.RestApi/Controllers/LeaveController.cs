using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Extensions;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Commands;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.CommandHandlers;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace Wsb.EmployeeSelfService.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IResponse<List<string>>> GetLeaveTypes()
        {
            var result = await Task.Run(() => Enum.GetValues(typeof(LeaveType))
                .Cast<LeaveType>()
                .Select(x => x.DisplayName()).OrderBy(x=>x)
                .ToList());
            return Response<List<string>>.CreateSuccess(result);

        }

        [HttpPost("[action]")]
        public async Task<IBaseResponse> SubmitLeave([FromBody] AddLeaveCommandQuery query) => await _mediator.Send(query);
    }
}
