using AutoMapper;
using BLL.Interfaces;
using DAL.Authentication;
using DAL.Entities;
using DAL.Interfaces;
using DTOs.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserRoles = DAL.Authentication.UserRoles;

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

            var user = await _repository.FindUserByName(mapped.Username);
            if (user != null && await _repository.IsCorrectPassword(user, mapped.Password))
            {
                var userRoles = await _repository.GetUserRoles(user);

                return _repository.GetTokenAndExpiration(userRoles, user.UserName);
            }
            else
            {
                throw new Exception("User is not registered");
            }
        }

        public async Task Register(RegisterModelDto model)
        {
            var mapped = _mapper.Map<RegisterModel>(model);
            await RegisterUser(mapped, UserRoles.User);
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
            await RegisterUser(mapped, UserRoles.Admin);
            await _statisticRepository.Create(new UserStatistics()
            {
                Id = 0,
                UserLogin = model.Username,
                Rating = 0,
                FinishedCourses = new(),
                FinishedThemes = new()
            });
        }

        private async Task RegisterUser(RegisterModel model, string roleName)
        {
            var userExists = await _repository.FindUserByName(model.Username);
            if (userExists != null)
                throw new Exception("User already exists!");

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _repository.CreateUser(user, model.Password);
            var errors = string.Join(", ", result.Errors.Select(x => x.Description));
            if (!result.Succeeded)
                throw new Exception("User creation failed! " + errors);

            if (!await _repository.DoRoleExist(UserRoles.Admin))
                await _repository.CreateRole(UserRoles.Admin);
            if (!await _repository.DoRoleExist(UserRoles.User))
                await _repository.CreateRole(UserRoles.User);
            if (!await _repository.DoRoleExist(UserRoles.ExpiriencedUser))
                await _repository.CreateRole(UserRoles.ExpiriencedUser);

            if (await _repository.DoRoleExist(roleName))
            {
                await _repository.AddUserToRole(user, roleName);
            }
            else
            {
                throw new Exception($"Role {roleName} does not exist.");
            }
        }
    }
}
