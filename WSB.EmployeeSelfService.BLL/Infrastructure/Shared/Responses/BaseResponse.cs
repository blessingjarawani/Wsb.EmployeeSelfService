using System;
using System.Collections.Generic;
using System.Text;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
