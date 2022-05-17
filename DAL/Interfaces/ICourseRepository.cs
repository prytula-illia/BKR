using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        public Task DeleteCourseWithData(int id);
    }
}
