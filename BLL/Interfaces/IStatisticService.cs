using DTOs;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStatisticService : ICrudService<UserStatisticsDto>
    {
        public Task<float> GetThemesFinishedRateForCourse(int statisticId, int courseId);

        public UserStatisticsDto GetByName(string name);
    }
}
