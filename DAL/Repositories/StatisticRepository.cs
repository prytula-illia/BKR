using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StatisticRepository : BaseRepository<UserStatistics>, IStatisticRepository
    {
        public StatisticRepository(Context context) : base(context)
        {
        }

        public IEnumerable<UserStatistics> GetAllStatisticsWithNested()
        {
            return _context.UserStatistics
                .Include(x => x.FinishedCourses)
                    .ThenInclude(x => x.Themes)
                .Include(x => x.FinishedThemes)
                    .ThenInclude(x => x.Course)
                .AsSplitQuery();
        }

        public UserStatistics GetByName(string name)
        {
            return _context.UserStatistics.Where(x => x.UserLogin == name)
                .Include(x => x.FinishedCourses)
                    .ThenInclude(x => x.Themes)
                .Include(x => x.FinishedThemes)
                    .ThenInclude(x => x.Course)
                .AsSplitQuery()
                .FirstOrDefault();
        }

        public UserStatistics GetWithNestedData(int id)
        {
            return _context.UserStatistics.Where(x => x.Id == id)
                .Include(x => x.FinishedCourses)
                    .ThenInclude(x => x.Themes)
                .Include(x => x.FinishedThemes)
                    .ThenInclude(x => x.Course)
                .AsSplitQuery()
                .FirstOrDefault();
        }

        public async Task UpdateStatistic(UserStatistics entity)
        {
            var oldEntity = GetWithNestedData(entity.Id);
            oldEntity.Rating = entity.Rating;
            var newCoursesIds = entity.FinishedCourses.Select(x => x.Id).Except(oldEntity.FinishedCourses.Select(x => x.Id));
            var newThemesIds = entity.FinishedThemes.Select(x => x.Id).Except(oldEntity.FinishedThemes.Select(x => x.Id));

            foreach(var i in newCoursesIds)
            {
                _context.Database.ExecuteSqlRaw($"INSERT INTO dbo.CourseUserStatistics VALUES ({i}, {entity.Id})");
            }

            foreach (var i in newThemesIds)
            {
                _context.Database.ExecuteSqlRaw($"INSERT INTO dbo.ThemeUserStatistics VALUES ({i}, {entity.Id})");
            }

            await Update(oldEntity);
        }
    }
}