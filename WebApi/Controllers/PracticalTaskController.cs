using BLL.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class PracticalTaskController : ControllerBase
    {
        private readonly ILogger<PracticalTaskController> _logger;
        private readonly IPracticalTaskService _service;

        public PracticalTaskController(ILogger<PracticalTaskController> logger, IPracticalTaskService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("api/practicalTask/")]
        public IEnumerable<PracticalTaskDto> GetAll()
        {
            _logger.LogInformation("Getting all practical tasks: " + DateTime.Now);
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/practicalTask/{id}")]
        public async Task<PracticalTaskDto> Get(int id)
        {
            _logger.LogInformation($"Get practical task with id {id}." + DateTime.Now);
            return await _service.Get(id);
        }

        [HttpPost]
        [Route("api/practicalTask/")]
        public async Task<int> Create([FromBody] PracticalTaskDto dto)
        {
            _logger.LogInformation($"Create practical task." + DateTime.Now);
            return await _service.Create(dto);
        }

        [HttpPut]
        [Route("api/practicalTask/")]
        public async Task Update([FromBody] PracticalTaskDto dto)
        {
            _logger.LogInformation($"Update practical task." + DateTime.Now);
            await _service.Update(dto);
        }

        [HttpDelete]
        [Route("api/practicalTask/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete practical task with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}