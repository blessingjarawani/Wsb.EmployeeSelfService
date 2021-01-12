using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Requests;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Responses;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Queries.Handlers.QueryHandlers
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, IResponse<UserDTO>>
    {
        private readonly IUsersRepository _userRepository;
        private readonly IEmployeeRepo _employeeRepo;

        public UserLoginQueryHandler(IUsersRepository userRepository, IEmployeeRepo employeeRepo)
        {
            _userRepository = userRepository;
            _employeeRepo = employeeRepo;
        }
        public async Task<IResponse<UserDTO>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
                    return Response<UserDTO>.CreateFail("Invalid Request");
                var result = await _userRepository.GetUser(request.UserName, request.Password);
                if (result == null)
                      return Response<UserDTO>.CreateFail("User not Found");
                if (result.EmployeeId.HasValue)
                    result.EmpCode = (await _employeeRepo.GetEmployeeByID(result.EmployeeId.Value))?.EmpCode ?? "";

                return Response<UserDTO>.CreateSuccess(result);
            }
            catch (Exception ex)
            {
                return Response<UserDTO>.CreateFail(ex.Message);

            }
        }
    }
}
