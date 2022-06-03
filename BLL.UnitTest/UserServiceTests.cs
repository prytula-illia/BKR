using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Authentication;
using DAL.Interfaces;
using DTOs.Authentication;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WebApi.Mapper;

namespace BLL.UnitTest
{
    public class UserServiceTests
    {
        IUserService _service;
        private IMapper _mapper;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IStatisticRepository> _statisticRepositoryMock;

        [SetUp]
        public void Setup()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            _mapper = cfg.CreateMapper();
            _userRepositoryMock = new Mock<IUserRepository>();
            var user = new ApplicationUser();
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync(user);
            _userRepositoryMock.Setup(x => x.IsCorrectPassword(user, It.IsAny<string>())).ReturnsAsync(true);
            _userRepositoryMock.Setup(x => x.GetUserRoles(user)).ReturnsAsync(new List<string>());
            _userRepositoryMock.Setup(x => x.GetTokenAndExpiration(It.IsAny<List<string>>(), It.IsAny<string>()))
                .Returns(new { });

            _userRepositoryMock.Setup(x => x.CreateUser(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(new IdentetySucceeded());

            _userRepositoryMock.Setup(x => x.DoRoleExist(It.IsAny<string>())).ReturnsAsync(true);

            _statisticRepositoryMock = new Mock<IStatisticRepository>();

            InitService();
        }

        [Test]
        public void Login_If_Data_Is_Correct_Returns_Expiration_Token()
        {
            Assert.DoesNotThrowAsync(() => _service.Login(new LoginModelDto()));
        }

        [Test]
        public void Login_If_User_Is_Not_Found_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.Login(new LoginModelDto()));
        }

        [Test]
        public void Login_If_Password_Is_Not_Correct_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.IsCorrectPassword(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(false);
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.Login(new LoginModelDto()));
        }

        [Test]
        public void Register_If_Data_Is_Correct_Returns_Expiration_Token()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            InitService();

            Assert.DoesNotThrowAsync(() => _service.Register(new RegisterModelDto()));
        }

        [Test]
        public void Register_If_User_Is_Registered_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.Register(new RegisterModelDto()));
        }

        [Test]
        public void Register_If_Creating_Failed_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userRepositoryMock.Setup(x => x.CreateUser(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(new IdentityResult());
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.Register(new RegisterModelDto()));
        }

        [Test]
        public void Register_If_Role_Does_Not_Exist_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userRepositoryMock.Setup(x => x.DoRoleExist(It.IsAny<string>())).ReturnsAsync(false);
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.Register(new RegisterModelDto()));
        }

        [Test]
        public void GrantExpiriencedUserRole_If_Data_Is_Ok_Grants_Does_Not_Throw_An_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());
            _userRepositoryMock.Setup(x => x.GetUserRoles(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string>()
            {
                DAL.Authentication.UserRoles.User
            }); 
            InitService();

            Assert.DoesNotThrowAsync(() => _service.GrantExpiriencedUserRole("username"));
        }

        [Test]
        public void GrantExpiriencedUserRole_If_No_User_Found_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userRepositoryMock.Setup(x => x.GetUserRoles(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string>()
            {
                DAL.Authentication.UserRoles.User
            });
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.GrantExpiriencedUserRole("username"));
        }

        [Test]
        public void GrantExpiriencedUserRole_If_User_Already_Has_Previlages_Throws_Exception()
        {
            _userRepositoryMock.Setup(x => x.FindUserByName(It.IsAny<string>())).ReturnsAsync(new ApplicationUser());
            _userRepositoryMock.Setup(x => x.GetUserRoles(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string>()
            {
                DAL.Authentication.UserRoles.ExpiriencedUser
            });
            InitService();

            Assert.ThrowsAsync<Exception>(() => _service.GrantExpiriencedUserRole("username"));
        }

        private void InitService()
        {
            _service = new UserService(_userRepositoryMock.Object, _statisticRepositoryMock.Object, _mapper);
        }

        private class IdentetySucceeded : IdentityResult
        {
            public IdentetySucceeded()
            {
                Succeeded = true;
            }
        }
    }
}
