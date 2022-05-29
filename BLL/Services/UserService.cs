using AutoMapper;
using BLL.Interfaces;
using DAL.Authentication;
using DAL.Entities;
using DAL.Interfaces;
using DTOs.Authentication;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private IStatisticRepository _statisticRepository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IStatisticRepository statisticRepository, IMapper mapper)
        {
            _repository = repository;
            _statisticRepository = statisticRepository;
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
            await _statisticRepository.Create(new UserStatistics()
            {
                Id = 0,
                UserLogin = model.Username,
                Rating = 0,
                FinishedCourses = new(),
                FinishedThemes = new()
            });
        }

        public async Task RegisterAdmin(RegisterModelDto model)
        {
            var mapped = _mapper.Map<RegisterModel>(model);
            await _repository.RegisterAdmin(mapped); 
            await _statisticRepository.Create(new UserStatistics()
            {
                Id = 0,
                UserLogin = model.Username,
                Rating = 0,
                FinishedCourses = new(),
                FinishedThemes = new()
            });
        }
    }
}
