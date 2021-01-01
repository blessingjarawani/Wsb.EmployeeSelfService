using System;
using System.Collections.Generic;
using System.Text;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses
{
    public class BaseResponse : IBaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        protected BaseResponse(bool isSuccess, string errorMessage = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
        public static BaseResponse CreateSuccess() => new BaseResponse(true);
        public static BaseResponse CreateFail(string message) => new BaseResponse(false, message);
    }
}
