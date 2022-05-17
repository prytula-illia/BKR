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
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IThemeRepository _themeRepository;
        private readonly IMapper _mapper;

        public StatisticService(IStatisticRepository repository,
            ICourseRepository courseRepository,
            IThemeRepository themeRepository,
            IMapper mapper)
        {
            _statisticRepository = repository;
            _courseRepository = courseRepository;
            _themeRepository = themeRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(UserStatisticsDto entity)
        {
            var statistic = _mapper.Map<UserStatistics>(entity);

            var result = await _statisticRepository.Create(statistic);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _statisticRepository.Delete(id);
        }

        public async Task<UserStatisticsDto> Get(int id)
        {
            var statistic = await _statisticRepository.Get(id);

            return _mapper.Map<UserStatisticsDto>(statistic);
        }

        public IEnumerable<UserStatisticsDto> GetAll()
        {
            var statistic = _statisticRepository.GetAll();

            return _mapper.Map<IEnumerable<UserStatisticsDto>>(statistic);
        }

        public async Task Update(UserStatisticsDto entity)
        {
            var statistic = _mapper.Map<UserStatistics>(entity);

            await _statisticRepository.Update(statistic);
        }

        public async Task<float> GetTasksFinishedRateForTheme(int statisticId, int themeId)
        {
            var statistic = await Get(statisticId);
            var theme = await _themeRepository.Get(themeId);

            var allCount = theme.Tasks.Count();
            var finishedCount = statistic.FinishedTasks.Count();

            return (float)finishedCount / allCount;
        }

        public async Task<float> GetThemesFinishedRateForCourse(int statisticId, int courseId)
        {
            var statistic = await Get(statisticId);
            var course = await _courseRepository.Get(courseId);

            var allCount = course.Themes.Count();
            var finishedCount = statistic.FinishedThemes.Count();

            return (float)finishedCount / allCount;
        }
    }
}
