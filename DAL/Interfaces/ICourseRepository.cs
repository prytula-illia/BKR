using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        public void DeleteCourseWithData(int id);
    }
}
