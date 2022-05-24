using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CommentRepository :  BaseRepository<Comment>, ICommentsRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }
    }
}
