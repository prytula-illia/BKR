using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentsRepository : IRepository<Comment>
    {
        public Task<Comment> GetWithNestedData(int id);
    }
}
