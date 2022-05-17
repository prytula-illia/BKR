using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(Context context) : base(context)
        {
        }

        public Task DeleteCourseWithData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
