using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DTOs;
using System.Collections.Generic;

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

        public void Create(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            _repository.Create(course);
        }

        public void Delete(int id)
        {
            _repository.DeleteCourseWithData(id);
        }

        public CourseDto Get(int id)
        {
            var course = _repository.Get(id);

            return _mapper.Map<CourseDto>(course);
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _repository.GetAll();

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public void Update(CourseDto entity)
        {
            var course = _mapper.Map<Course>(entity);

            _repository.Update(course);
        }
    }
}
