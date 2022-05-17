using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StatisticRepository : BaseRepository<UserStatistics>, IStatisticRepository
    {
        public StatisticRepository(Context context) : base(context)
        {
        }
    }
}