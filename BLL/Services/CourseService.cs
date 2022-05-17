using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Create(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            var result = await _repository.Create(course);

            return result.Id;
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteCourseWithData(id);
        }

        public async Task<CourseDto> Get(int id)
        {
            var course = await _repository.Get(id);

            return _mapper.Map<CourseDto>(course);
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _repository.GetAll();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task Update(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            await _repository.Update(course);
        }
    }
}
