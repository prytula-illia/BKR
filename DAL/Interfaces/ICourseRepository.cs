using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        public IEnumerable<Course> GetAllCoursesWithNestedData();
        public Task<Course> GetCourseWithAllNestedData(int id);
    }
}
