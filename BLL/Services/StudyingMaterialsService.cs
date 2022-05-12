using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;

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

        public void Create(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            _repository.Create(material);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public StudyingMaterialsDto Get(int id)
        {
            var material = _repository.Get(id);

            return _mapper.Map<StudyingMaterialsDto>(material);
        }

        public IEnumerable<StudyingMaterialsDto> GetAll()
        {
            var materials = _repository.GetAll();

            return _mapper.Map<IEnumerable<StudyingMaterialsDto>>(materials);
        }

        public void Update(StudyingMaterialsDto entity)
        {
            var material = _mapper.Map<StudyingMaterials>(entity);

            _repository.Update(material);
        }
    }
}
