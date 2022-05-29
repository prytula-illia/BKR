using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStatisticRepository : IRepository<UserStatistics>
    {
        public UserStatistics GetByName(string name);
        public UserStatistics GetWithNestedData(int id);
        public Task UpdateStatistic(UserStatistics entity);
    }
}
