using DTOs;

namespace BLL.Interfaces
{
    public interface IStatisticService : ICrudService<UserStatisticsDto>
    {
        public float GetThemesFinishedRateForCourse(int statisticId, int courseId);
        public float GetTasksFinishedRateForTheme(int statisticId, int themeId);
    }
}
