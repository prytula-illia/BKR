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
        private readonly IStudyingMaterialsRepository _repository;
        private readonly IMapper _mapper;

        public StudyingMaterialsService(IStudyingMaterialsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            var result = await _repository.Create(material);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<StudyingMaterialsDto> Get(int id)
        {
            var material = await _repository.Get(id);

            return _mapper.Map<StudyingMaterialsDto>(material);
        }

        public IEnumerable<StudyingMaterialsDto> GetAll()
        {
            var materials = _repository.GetAll();

            return _mapper.Map<IEnumerable<StudyingMaterialsDto>>(materials);
        }

        public async Task Update(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            await _repository.Update(material);
        }
    }
}
