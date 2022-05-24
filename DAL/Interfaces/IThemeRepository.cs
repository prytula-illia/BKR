using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IThemeRepository : IRepository<Theme>
    {
        public IEnumerable<Theme> GetAllThemesWithNestedData();
        public Task<Theme> GetWithNestedData(int id);
    }
}
