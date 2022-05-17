using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(Context context) : base(context)
        {
        }
    }
}
