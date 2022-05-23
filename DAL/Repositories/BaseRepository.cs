using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            var result = _context.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Find<T>(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
