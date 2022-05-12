using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(UserStatisticsDto entity)
        {
            var statistic = _mapper.Map<UserStatistics>(entity);

            _statisticRepository.Create(statistic);
        }

        public void Delete(int id)
        {
            _statisticRepository.Delete(id);
        }

        public UserStatisticsDto Get(int id)
        {
            var statistic = _statisticRepository.Get(id);

            return _mapper.Map<UserStatisticsDto>(statistic);
        }

        public IEnumerable<UserStatisticsDto> GetAll()
        {
            var statistic = _statisticRepository.GetAll();

            return _mapper.Map<IEnumerable<UserStatisticsDto>>(statistic);
        }

        public void Update(UserStatisticsDto entity)
        {
            var statistic = _mapper.Map<UserStatistics>(entity);

            _statisticRepository.Update(statistic);
        }

        public float GetTasksFinishedRateForTheme(int statisticId, int themeId)
        {
            var statistic = Get(statisticId);
            var theme = _themeRepository.Get(themeId);

            var allCount = theme.Tasks.Count();
            var finishedCount = statistic.FinishedTasks.Count();

            return (float)finishedCount / allCount;
        }

        public float GetThemesFinishedRateForCourse(int statisticId, int courseId)
        {
            var statistic = Get(statisticId);
            var course = _courseRepository.Get(courseId);

            var allCount = course.Themes.Count();
            var finishedCount = statistic.FinishedThemes.Count();

            return (float)finishedCount / allCount;
        }
    }
}
