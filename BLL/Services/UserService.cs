using AutoMapper;
using BLL.Interfaces;
using DAL.Authentication;
using DAL.Interfaces;
using DTOs.Authentication;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<object> Login(LoginModelDto model)
        {
            var mapped = _mapper.Map<LoginModel>(model);
            return await _repository.Login(mapped);
        }

        public async Task Register(RegisterModelDto model)
        {
            var mapped = _mapper.Map<RegisterModel>(model);
            await _repository.Register(mapped);
        }

        public async Task RegisterAdmin(RegisterModelDto model)
        {
            var mapped = _mapper.Map<RegisterModel>(model);
            await _repository.RegisterAdmin(mapped);
        }
    }
}
