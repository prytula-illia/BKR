using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentsRepository _repository;
        private readonly IStudyingMaterialsRepository _studyingMaterialsRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentsRepository repository, IStudyingMaterialsRepository studyingMaterialsRepository, IMapper mapper)
        {
            _repository = repository;
            _studyingMaterialsRepository = studyingMaterialsRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(CommentDto entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            var result = await _repository.Create(comment);

            return result.Id;
        }

        public async Task<int> Create(int studyingMaterialId, CommentDto entity)
        {
            var comment = _mapper.Map<Comment>(entity);
            var material = await _studyingMaterialsRepository.GetWithNestedData(studyingMaterialId);
            if(material is null)
            {
                throw new Exception($"There are no material with id ${studyingMaterialId}.");
            }
            material.Comments.Add(comment);
            await _studyingMaterialsRepository.Update(material);

            var updated = await _studyingMaterialsRepository.Get(studyingMaterialId);
            var result = updated.Comments.FirstOrDefault(x => x.DateTime == entity.DateTime);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<CommentDto> Get(int id)
        {
            var comment = await _repository.GetWithNestedData(id);

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

        public async Task UpdateRating(CommentRatingsDto dto)
        {
            var comment = await _repository.GetWithNestedData(dto.CommentId);
            if (comment is null)
                return;

            var entity = comment.CommentRatings.FirstOrDefault(x => x.Username == dto.Username);

            var mapped = _mapper.Map<CommentRating>(dto);
            if (entity is null)
            {
                comment.CommentRatings.Add(mapped);
            }
            else
            {
                for (int i = 0; i < comment.CommentRatings.Count; ++i)
                {
                    if (comment.CommentRatings[i].Username == dto.Username)
                    {
                        comment.CommentRatings[i] = mapped;
                        break;
                    }
                }
            }

            await _repository.Update(comment);
        }
    }
}
