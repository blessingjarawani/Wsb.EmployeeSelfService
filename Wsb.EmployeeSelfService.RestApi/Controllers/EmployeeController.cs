using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Extensions;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.QueryHandlers;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;
using static WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Dictionary.Dictionary;

namespace Wsb.EmployeeSelfService.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IResponse<IEnumerable<EmployeeDTO>>> GetAllEmployees([FromBody] GetAllEmployeesQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpPost("[action]")]
        public async Task<IResponse<EmployeeDTO>> GetEmployeeByCode([FromBody] GetEmployeeByEmployeeCodeQuery query)
        {
            return await _mediator.Send(query);
        }

       

    }
}
