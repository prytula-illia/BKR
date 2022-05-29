using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(Context context) : base(context)
        {
        }

        public IEnumerable<Course> GetAllCoursesWithNestedData()
        {
            return _context.Courses
                .Include(x => x.Themes)
                    .ThenInclude(x => x.Tasks)
                        .ThenInclude(x => x.Answers)
                .Include(x => x.Themes)
                    .ThenInclude(x => x.StudyingMaterials)
                        .ThenInclude(x => x.Comments)
                .AsSplitQuery();
        }

        public async Task<Course> GetCourseWithAllNestedData(int id)
        {
            return await _context.Courses.Where(x => x.Id == id)
                .Include(x => x.Themes)
                    .ThenInclude(x => x.Tasks)
                        .ThenInclude(x => x.Answers)
                .Include(x => x.Themes)
                    .ThenInclude(x => x.StudyingMaterials)
                        .ThenInclude(x => x.Comments)
                .AsSplitQuery()
                .FirstOrDefaultAsync();
        }
    }
}
