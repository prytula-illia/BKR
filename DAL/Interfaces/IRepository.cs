using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<T> Get(int id);
        public IEnumerable<T> GetAll();
        public Task<T> Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
