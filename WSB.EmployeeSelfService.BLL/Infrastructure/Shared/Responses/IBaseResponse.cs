using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses
{
    public interface IBaseResponse
    {
        bool IsSuccess { get; }
        string ErrorMessage { get; }
    }
}
