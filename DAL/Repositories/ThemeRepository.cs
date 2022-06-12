using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ThemeRepository : BaseRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(Context context) : base(context)
        {
        }

        public IEnumerable<Theme> GetAllThemesWithNestedData()
        {
            return _context.Themes
                .Include(x => x.Tasks)
                    .ThenInclude(x => x.Answers)
                .Include(x => x.StudyingMaterials)
                    .ThenInclude(x => x.Comments)
                        .ThenInclude(x => x.CommentRatings)
                .Include(x => x.ThemeRatings)
                .AsSplitQuery()
                .ToList();
        }

        public async Task<Theme> GetWithNestedData(int id)
        {
            var result = await _context.Themes.Where(x => x.Id == id)
                .Include(x => x.Tasks)
                    .ThenInclude(x => x.Answers)
                .Include(x => x.StudyingMaterials)
                    .ThenInclude(x => x.Comments)
                        .ThenInclude(x => x.CommentRatings)
                .Include(x => x.Course)
                .Include(x => x.ThemeRatings)
                .AsSplitQuery()
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
