using AutoMapper;
using BLL.Interfaces;
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

        public IEnumerable<StudyingMaterialsDto> GetAllStudyingMaterials()
        {
            var materials = _repository.GetAll();

            return _mapper.Map<IEnumerable<StudyingMaterialsDto>>(materials);
        }
    }
}
