using System;
using System.Collections.Generic;
using System.Text;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses
{
    public class Response<T> : BaseResponse, IResponse<T>
    {
        public T Data { get; }
      
        private Response(T result, bool isSuccess, string message = null) : base(isSuccess, message)
        {
            Data = result;
        }
        private Response(bool isSuccess, string message = null) : base(isSuccess, message)
        {
        }
        public static Response<T> CreateSuccess(T result) => new Response<T>(result, true);
        public static Response<T> CreateFail(string message) => new Response<T>(false, message);
    }
}
