using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        public T Get(int id);
        public IEnumerable<T>GetAll();
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(int id);
    }
}
