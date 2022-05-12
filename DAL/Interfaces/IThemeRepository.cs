using DAL.Entities;

namespace DAL.Interfaces
{
    interface IThemeRepository : IRepository<Theme>
    {
        public void DeleteThemeWithData(int id);
    }
}
