using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        public Task<T> Get(int id);
        public IEnumerable<T>GetAll();
        public Task<int> Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
