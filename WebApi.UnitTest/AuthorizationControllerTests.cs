using BLL.Interfaces;
using DTOs.Authentication;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi.UnitTest
{
    public class AuthorizationControllerTests
    {
        Mock<IUserService> _serviceMock;
        AuthorizationController _controller;

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Login(It.IsAny<LoginModelDto>())).ReturnsAsync(new { });

            InitController();
        }

        [Test]
        public async Task Login_If_Service_Didnt_Throw_An_Error_Returns_OK()
        {
            var result = await _controller.Login(new LoginModelDto());

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Login_If_Service_Throws_An_Error_Returns_500()
        {
            _serviceMock.Setup(x => x.Login(It.IsAny<LoginModelDto>())).ThrowsAsync(new Exception("Exception!"));

            var result = await _controller.Login(new LoginModelDto());

            if(result is ObjectResult res)
            {
                Assert.AreEqual(500, res.StatusCode);
                Assert.AreEqual("Exception!", res.Value);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task Register_If_Service_Didnt_Throw_An_Error_Returns_OK()
        {
            var result = await _controller.Register(new RegisterModelDto());

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task Register_If_Service_Throws_An_Error_Returns_500()
        {
            _serviceMock.Setup(x => x.Register(It.IsAny<RegisterModelDto>())).ThrowsAsync(new Exception("Exception!"));

            var result = await _controller.Register(new RegisterModelDto());

            if (result is ObjectResult res)
            {
                Assert.AreEqual(500, res.StatusCode);
                Assert.AreEqual("Exception!", res.Value);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task RegisterAdmin_If_Service_Didnt_Throw_An_Error_Returns_OK()
        {
            var result = await _controller.RegisterAdmin(new RegisterModelDto());

            Assert.IsInstanceOf<OkResult>(result);
        }

        [Test]
        public async Task RegisterAdmin_If_Service_Throws_An_Error_Returns_500()
        {
            _serviceMock.Setup(x => x.RegisterAdmin(It.IsAny<RegisterModelDto>())).ThrowsAsync(new Exception("Exception!"));

            var result = await _controller.RegisterAdmin(new RegisterModelDto());

            if (result is ObjectResult res)
            {
                Assert.AreEqual(500, res.StatusCode);
                Assert.AreEqual("Exception!", res.Value);
            }
            else
            {
                Assert.Fail();
            }
        }

        public void InitController()
        {
            _controller = new AuthorizationController(_serviceMock.Object);
        }
    }
}
