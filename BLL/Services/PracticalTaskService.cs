using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PracticalTaskService : IPracticalTaskService
    {
        private readonly IPracticalTaskRepository _repository;
        private readonly IMapper _mapper;

        public PracticalTaskService(IPracticalTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            var result = await _repository.Create(task);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<PracticalTaskDto> Get(int id)
        {
            var task = await _repository.Get(id);

            return _mapper.Map<PracticalTaskDto>(task);
        }

        public IEnumerable<PracticalTaskDto> GetAll()
        {
            var tasks = _repository.GetAll();

            return _mapper.Map<IEnumerable<PracticalTaskDto>>(tasks);
        }

        public async Task Update(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            await _repository.Update(task);
        }
    }
}
