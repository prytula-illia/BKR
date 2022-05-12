using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;

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

        public void Create(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            _repository.Create(task);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public PracticalTaskDto Get(int id)
        {
            var task = _repository.Get(id);

            return _mapper.Map<PracticalTaskDto>(task);
        }

        public IEnumerable<PracticalTaskDto> GetAll()
        {
            var tasks = _repository.GetAll();

            return _mapper.Map<IEnumerable<PracticalTaskDto>>(tasks);
        }

        public void Update(PracticalTaskDto entity)
        {
            var task = _mapper.Map<PracticalTask>(entity);

            _repository.Update(task);
        }
    }
}
