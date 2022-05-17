using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PracticalTaskRepository : BaseRepository<PracticalTask>, IPracticalTaskRepository
    {
        public PracticalTaskRepository(Context context) : base(context)
        {
        }
    }
}
