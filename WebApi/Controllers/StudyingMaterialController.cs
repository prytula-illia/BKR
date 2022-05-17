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
    public class StudyingMaterialController : ControllerBase
    {
        private readonly ILogger<StudyingMaterialController> _logger;
        private readonly IStudyingMaterialsService _service;

        public StudyingMaterialController(ILogger<StudyingMaterialController> logger, IStudyingMaterialsService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("api/studyingMaterial/all")]
        public IEnumerable<StudyingMaterialsDto> GetAll()
        {
            _logger.LogInformation("Getting all studying materials: " + DateTime.Now);
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/studyingMaterial/{id}")]
        public async Task<StudyingMaterialsDto> Get(int id)
        {
            _logger.LogInformation($"Get studying material with id {id}." + DateTime.Now);
            return await _service.Get(id);
        }

        [HttpPost]
        [Route("api/studyingMaterial/create")]
        public async Task<int> Create([FromBody] StudyingMaterialsDto dto)
        {
            _logger.LogInformation($"Create studying material." + DateTime.Now);
            return await _service.Create(dto);
        }

        [HttpPut]
        [Route("api/studyingMaterial/update")]
        public async Task Update([FromBody] StudyingMaterialsDto dto)
        {
            _logger.LogInformation($"Update studying material." + DateTime.Now);
            await _service.Update(dto);
        }

        [HttpDelete]
        [Route("api/studyingMaterial/delete/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete studying material with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}
