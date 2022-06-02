using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebApi.Mapper;

namespace BLL.UnitTest
{
    public class ThemeServiceTests
    {
        IThemeService _service;
        private IMapper _mapper;
        private Mock<IThemeRepository> _themeRepositoryMock;
        private Mock<ICourseRepository> _courseRepositoryMock;
        private Mock<IPracticalTaskRepository> _practicalTaskRepositoryMock;
        private Mock<IStudyingMaterialsRepository> _studyingMaterialsRepositoryMock;

        [SetUp]
        public void Setup()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            _mapper = cfg.CreateMapper();
            _themeRepositoryMock = new Mock<IThemeRepository>();
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _practicalTaskRepositoryMock = new Mock<IPracticalTaskRepository>();
            _studyingMaterialsRepositoryMock = new Mock<IStudyingMaterialsRepository>();

            InitService();
        }

        [Test]
        public void Search_Returns_Titles_Matched_By_Name_With_No_Case_Check()
        {
            var listOfThemes = GetListOfThemes();

            _themeRepositoryMock.Setup(x => x.GetAllThemesWithNestedData()).Returns(listOfThemes);
            InitService();

            var result = _service.SearchThemes("TITLE").ToList();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(listOfThemes[1].Title, result[0].Title);
            Assert.AreEqual(listOfThemes[3].Title, result[1].Title);
        }

        [Test]
        public void Search_Returns_Titles_Matched_By_Partial_Match()
        {
            var listOfThemes = GetListOfThemes();

            _themeRepositoryMock.Setup(x => x.GetAllThemesWithNestedData()).Returns(listOfThemes);
            InitService();

            var result = _service.SearchThemes("TIT").ToList();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(listOfThemes[1].Title, result[0].Title);
            Assert.AreEqual(listOfThemes[3].Title, result[1].Title);
        }

        [Test]
        public void Search_Returns_Empty_List_If_No_Matches()
        {
            var listOfThemes = GetListOfThemes();

            _themeRepositoryMock.Setup(x => x.GetAllThemesWithNestedData()).Returns(listOfThemes);
            InitService();

            var result = _service.SearchThemes("000").ToList();
            Assert.IsEmpty(result);
        }

        private void InitService()
        {
            _service = new ThemeService(_themeRepositoryMock.Object,
                _courseRepositoryMock.Object,
                _practicalTaskRepositoryMock.Object,
                _studyingMaterialsRepositoryMock.Object,
                _mapper);
        }

        private List<Theme> GetListOfThemes() => new List<Theme>()
        {
            new()
            {
                Title = "something"
            },
            new()
            {
                Title = "X one title"
            },
            new()
            {
                Title = "something"
            },
            new()
            {
                Title = "X two TitLe"
            }
        };
    }
}
