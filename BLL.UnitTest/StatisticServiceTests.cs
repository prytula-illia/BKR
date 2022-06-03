using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WebApi.Mapper;

namespace BLL.UnitTest
{
    public class StatisticServiceTests
    {
        private IStatisticService _service;
        private Mock<IStatisticRepository> _statisticRepositoryMock;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            _mapper = cfg.CreateMapper();
            _statisticRepositoryMock = new Mock<IStatisticRepository>();
            _courseRepositoryMock = new Mock<ICourseRepository>();

            InitService();
        }

        [Test]
        public async Task GetThemesFinishedRateForCourse_Returns_Expected_Rate()
        {
            _statisticRepositoryMock.Setup(x => x.GetWithNestedData(It.IsAny<int>())).Returns(new UserStatistics()
            {
                FinishedThemes = new()
                {
                    new()
                    {
                        Id = 1,
                        Course = new()
                        {
                            Id = 2
                        }
                    },
                    new()
                    {
                        Id = 4,
                        Course = new()
                        {
                            Id = 2
                        }
                    },
                }
            });

            _courseRepositoryMock.Setup(x => x.GetCourseWithAllNestedData(It.IsAny<int>())).ReturnsAsync(new Course()
            {
                Themes = new()
                {
                    new()
                    {
                        Id = 1,
                        Course = new()
                        {
                            Id = 2
                        }
                    },
                    new()
                    {
                        Id = 4,
                        Course = new()
                        {
                            Id = 2
                        }
                    },
                    new()
                    {
                        Id = 111,
                        Course = new()
                        {
                            Id = 5
                        }
                    },
                    new()
                    {
                        Id = 112,
                        Course = new()
                        {
                            Id = 6
                        }
                    },
                }
            });

            InitService();

            var actual = await _service.GetThemesFinishedRateForCourse(1, 2);
            Assert.AreEqual(0.5, actual);
        }

        [Test]
        public async Task GetThemesFinishedRateForCourse_Returns_Zero_If_Course_Has_No_Themes()
        {
            _statisticRepositoryMock.Setup(x => x.GetWithNestedData(It.IsAny<int>())).Returns(new UserStatistics()
            {
                FinishedThemes = new()
                {
                    new()
                    {
                        Id = 1
                    },
                }
            });

            _courseRepositoryMock.Setup(x => x.GetCourseWithAllNestedData(It.IsAny<int>())).ReturnsAsync(new Course()
            {
                Themes = new()
            });

            InitService();
            
            var actual = await _service.GetThemesFinishedRateForCourse(1, 2);
            Assert.AreEqual(0, actual);
        }

        [Test]
        public async Task GetThemesFinishedRateForCourse_Does_Not_Throw_Error_If_No_Themes()
        {
            _statisticRepositoryMock.Setup(x => x.GetWithNestedData(It.IsAny<int>())).Returns(new UserStatistics()
            {
                FinishedThemes = new()
            });

            _courseRepositoryMock.Setup(x => x.GetCourseWithAllNestedData(It.IsAny<int>())).ReturnsAsync(new Course()
            {
                Themes = new()
            });

            InitService();

            Assert.DoesNotThrowAsync(() => _service.GetThemesFinishedRateForCourse(1, 2));
        }

        private void InitService()
        {
            _service = new StatisticService(_statisticRepositoryMock.Object,
                _courseRepositoryMock.Object,
                _mapper);
        }
    }
}