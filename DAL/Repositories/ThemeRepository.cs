using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ThemeRepository : BaseRepository<Theme>, IThemeRepository
    {
        public ThemeRepository(Context context) : base(context)
        {
        }

        public Task DeleteThemeWithData(int id)
        {
            throw new NotImplementedException();
        }
    }
}
