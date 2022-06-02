using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IPracticalTaskRepository _practicalTaskRepository;
        private readonly IStudyingMaterialsRepository _studyingMaterialsRepository;
        private readonly IMapper _mapper;

        public ThemeService(IThemeRepository themeRepository,
                            ICourseRepository courseRepository, 
                            IPracticalTaskRepository practicalTaskRepository,
                            IStudyingMaterialsRepository studyingMaterialsRepository,
                            IMapper mapper)
        {
            _themeRepository = themeRepository;
            _courseRepository = courseRepository;
            _practicalTaskRepository = practicalTaskRepository;
            _studyingMaterialsRepository = studyingMaterialsRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            var result = await _themeRepository.Create(theme);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            var theme = await Get(id);

            foreach(var t in theme.Tasks)
            {
                await _practicalTaskRepository.Delete(t.Id);
            }

            foreach(var sm in theme.StudyingMaterials)
            {
                await _studyingMaterialsRepository.Delete(sm.Id);
            }

            await _themeRepository.Delete(id);
        }

        public async Task<ThemeDto> Get(int id)
        {
            var theme = await _themeRepository.GetWithNestedData(id);

            return _mapper.Map<ThemeDto>(theme);
        }

        public IEnumerable<ThemeDto> GetAll()
        {
            var themes = _themeRepository.GetAllThemesWithNestedData();

            return _mapper.Map<IEnumerable<ThemeDto>>(themes);
        }

        public async Task Update(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            await _themeRepository.Update(theme);
        }

        public IEnumerable<ThemeDto> SearchThemes(string themeName)
        {
            return GetAll().Where(x => x.Title.ToLower().Contains(themeName.ToLower()));
        }

        public async Task<IEnumerable<ThemeDto>> GetCourseThemes(int id)
        {
            var course = await _courseRepository.GetCourseWithAllNestedData(id);

            return _mapper.Map<IEnumerable<ThemeDto>>(course.Themes);
        }

        public async Task<int> CreateThemeForCourse(ThemeDto dto, int courseId)
        {
            var course = await _courseRepository.Get(courseId);
            var theme = _mapper.Map<Theme>(dto);
            theme.Course = course;

            var result = await _themeRepository.Create(theme);
            return result.Id;
        }
    }
}
