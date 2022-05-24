using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudyingMaterialsService : IStudyingMaterialsService
    {
        private readonly IStudyingMaterialsRepository _studyingMaterialsRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public StudyingMaterialsService(IStudyingMaterialsRepository repository, ICommentsRepository commentsRepository, IMapper mapper)
        {
            _studyingMaterialsRepository = repository;
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            var result = await _studyingMaterialsRepository.Create(material);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            var material = await _studyingMaterialsRepository.Get(id);

            foreach (var c in material.Comments)
            {
                await _commentsRepository.Delete(c.Id);
            }

            await _studyingMaterialsRepository.Delete(id);
        }

        public async Task<StudyingMaterialsDto> Get(int id)
        {
            var material = await _studyingMaterialsRepository.Get(id);

            return _mapper.Map<StudyingMaterialsDto>(material);
        }

        public IEnumerable<StudyingMaterialsDto> GetAll()
        {
            var materials = _studyingMaterialsRepository.GetAll();

            return _mapper.Map<IEnumerable<StudyingMaterialsDto>>(materials);
        }

        public async Task Update(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            await _studyingMaterialsRepository.Update(material);
        }
    }
}
