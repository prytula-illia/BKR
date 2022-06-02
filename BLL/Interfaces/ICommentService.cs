using DTOs;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService : ICrudService<CommentDto>
    {
        public Task<int> Create(int studyingMaterialId, CommentDto entity);
    }
}
