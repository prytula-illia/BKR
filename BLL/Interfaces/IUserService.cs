using DTOs.Authentication;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public Task<object> Login(LoginModelDto model);
        public Task Register(RegisterModelDto model);
        public Task RegisterAdmin(RegisterModelDto model);
        public Task GrantExpiriencedUserRole(string userName);
    }
}
