using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class LearnModuleService : ILearnModuleService
    {
        private readonly IRepository<LearnModule> _repository;
        private readonly IMapper _mapper;

        public LearnModuleService(IRepository<LearnModule> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<LearnModuleDto> GetAllLearnModules()
        {
            var forecasts = _repository.GetAll();

            return _mapper.Map<IEnumerable<LearnModuleDto>>(forecasts);
        }
    }
}
