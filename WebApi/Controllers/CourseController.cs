using BLL.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _service;

        public CourseController(ILogger<CourseController> logger, ICourseService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("api/course/all")]
        public IEnumerable<CourseDto> GetAll()
        {
            _logger.LogInformation("Getting all courses: " + DateTime.Now);
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/course/{id}")]
        public async Task<CourseDto> Get(int id)
        {
            _logger.LogInformation($"Get course with id {id}." + DateTime.Now);
            return await _service.Get(id);
        }

        [HttpPost]
        [Route("api/course/create")]
        public async Task<int> Create([FromBody] CourseDto dto)
        {
            _logger.LogInformation($"Create course." + DateTime.Now);
            return await _service.Create(dto);
        }

        [HttpPut]
        [Route("api/course/update")]
        public async Task Update([FromBody] CourseDto dto)
        {
            _logger.LogInformation($"Update course." + DateTime.Now);
            await _service.Update(dto);
        }

        [HttpDelete]
        [Route("api/course/delete/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete course with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}
