using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;
using WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces;
using WSB.EmployeeSelfService.DAL.DataContexts;

namespace WSB.EmployeeSelfService.DAL.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly WSBEmployeeSelfServiceDataContext _dbContext;
        private readonly IMapper _mapper;
        public UsersRepository(WSBEmployeeSelfServiceDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUser(string userName, string password)
        {
            var result = await _dbContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
            return _mapper.Map<UserDTO>(result);
        }
    }
}
