using DAL.Authentication;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<object> Login(LoginModel loginModel);
        public Task Register(RegisterModel registerModel);
        public Task RegisterAdmin(RegisterModel registerModel);
    }
}
