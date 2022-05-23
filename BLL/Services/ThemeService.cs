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
        private readonly IMapper _mapper;

        public ThemeService(IThemeRepository themeRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _themeRepository = themeRepository;
            _courseRepository = courseRepository;
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
            await _themeRepository.DeleteThemeWithData(id);
        }

        public async Task<ThemeDto> Get(int id)
        {
            var theme = await _themeRepository.Get(id);

            return _mapper.Map<ThemeDto>(theme);
        }

        public IEnumerable<ThemeDto> GetAll()
        {
            var themes = _themeRepository.GetAll();

            return _mapper.Map<IEnumerable<ThemeDto>>(themes);
        }

        public async Task Update(ThemeDto entity)
        {
            var theme = _mapper.Map<Theme>(entity);

            await _themeRepository.Update(theme);
        }

        public IEnumerable<ThemeDto> SearchThemes(string themeName)
        {
            return GetAll().Where(x => x.Title.Contains(themeName));
        }

        public async Task<IEnumerable<ThemeDto>> GetCourseThemes(int id)
        {
            var course = await _courseRepository.Get(id);

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
