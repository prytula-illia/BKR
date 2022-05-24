using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(CommentDto entity)
        {
            var comment = _mapper.Map<Comment>(entity);

            var result = await _repository.Create(comment);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CommentDto> Get(int id)
        {
            var comment = await _repository.Get(id);

            return _mapper.Map<CommentDto>(comment);
        }

        public IEnumerable<CommentDto> GetAll()
        {
            var comments = _repository.GetAll();

            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task Update(CommentDto entity)
        {
            var comment = _mapper.Map<Comment>(entity);

            await _repository.Update(comment);
        }
    }
}
