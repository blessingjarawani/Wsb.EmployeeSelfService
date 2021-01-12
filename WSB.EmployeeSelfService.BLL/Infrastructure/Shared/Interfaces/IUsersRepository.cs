using System.Threading.Tasks;
using WSB.EmployeeSelfService.BLL.Infrastructure.DTO;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Interfaces
{
    public interface IUsersRepository
    {
        Task<UserDTO> GetUser(string userName, string password);
    }
}
