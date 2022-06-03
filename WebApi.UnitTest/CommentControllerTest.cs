using Moq;
using NUnit.Framework;
using WebApi.Controllers;
using System;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.Extensions.Logging;
using DTOs;

namespace WebApi.UnitTest
{
    public class CommentControllerTest
    {
        Mock<ILogger<CommentController>> _loggerMock;
        Mock<ICommentService> _serviceMock;
        CommentDto _dto;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<CommentController>>();
            _serviceMock = new Mock<ICommentService>();

            _dto = new CommentDto
            {
                Id = 0,
                Content = "some content",
                DateTime = DateTime.Now,
                UserName = "admin"
            };
        }

        [Test]
        public async Task Create_If_Dto_Provided_Returns_Expected_Id()
        {
            int expectedId = 111;
            _serviceMock.Setup(x => x.Create(It.IsAny<int>(), _dto)).Returns(Task.FromResult(expectedId));
            
            var controller = new CommentController(_loggerMock.Object, _serviceMock.Object);

            var id = await controller.Create(1, _dto);

            Assert.AreEqual(expectedId, id);
        }
    }
}
