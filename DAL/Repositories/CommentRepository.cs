using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CommentRepository :  BaseRepository<Comment>, ICommentsRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }

        public async Task<Comment> GetWithNestedData(int id)
        {
            var result = await _context.Comments.Where(x => x.Id == id)
                .Include(x => x.CommentRatings)
                .AsSplitQuery()
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}
