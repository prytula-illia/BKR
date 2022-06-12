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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IThemeRepository _themeRepository;
        private readonly IStatisticRepository _statisticRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, 
            IThemeRepository themeRepository,
            IStatisticRepository statisticRepository,
            IMapper mapper)
        {
            _courseRepository = repository;
            _themeRepository = themeRepository;
            _statisticRepository = statisticRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            var result = await _courseRepository.Create(course);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            var course = await _courseRepository.GetCourseWithAllNestedData(id);
            var themeIds = course.Themes.Select(x => x.Id).ToList();

            foreach (var t in themeIds)
            {
                await _themeRepository.Delete(t);
            }

            await _courseRepository.Delete(id);
        }

        public async Task<CourseDto> Get(int id)
        {
            var course = await _courseRepository.Get(id);

            return _mapper.Map<CourseDto>(course);
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _courseRepository.GetAllCoursesWithNestedData();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task Update(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            await _courseRepository.Update(course);
        }
    }
}
