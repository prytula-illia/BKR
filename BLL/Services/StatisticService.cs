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
        private readonly IMapper _mapper;

        public StatisticService(IStatisticRepository repository,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _statisticRepository = repository;
            _courseRepository = courseRepository;
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
            await _statisticRepository.UpdateStatistic(statistic);
        }

        public async Task<float> GetThemesFinishedRateForCourse(int statisticId, int courseId)
        {
            var statistic = _statisticRepository.GetWithNestedData(statisticId);
            var course = await _courseRepository.GetCourseWithAllNestedData(courseId);

            var allCount = course.Themes?.Count;
            if (allCount == 0)
                return 0;

            var finishedCount = statistic?.FinishedThemes.Where(x => x.Course?.Id == courseId).Count();

            return (float)finishedCount / (float)allCount;
        }

        public UserStatisticsDto GetByName(string name)
        {
            var statistic = _statisticRepository.GetByName(name);

            return _mapper.Map<UserStatisticsDto>(statistic);
        }
    }
}
