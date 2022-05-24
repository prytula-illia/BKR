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
        private readonly IPracticalTaskRepository _practicalTaskRepository;
        private readonly IMapper _mapper;

        public PracticalTaskService(IPracticalTaskRepository repository, IMapper mapper)
        {
            _practicalTaskRepository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            var result = await _practicalTaskRepository.Create(task);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _practicalTaskRepository.Delete(id);
        }

        public async Task<PracticalTaskDto> Get(int id)
        {
            var task = await _practicalTaskRepository.Get(id);

            return _mapper.Map<PracticalTaskDto>(task);
        }

        public IEnumerable<PracticalTaskDto> GetAll()
        {
            var tasks = _practicalTaskRepository.GetAll();

            return _mapper.Map<IEnumerable<PracticalTaskDto>>(tasks);
        }

        public async Task Update(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            await _practicalTaskRepository.Update(task);
        }
    }
}
