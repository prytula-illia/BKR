using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IStatisticRepository : IRepository<UserStatistics>
    {
        public float GetThemesFinishedRateForCourse(int id);
        public float GetTasksFinishedRateForTheme(int id);
    }
}
