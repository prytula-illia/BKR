using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IThemeRepository : IRepository<Theme>
    {
        public Task DeleteThemeWithData(int id);
    }
}
