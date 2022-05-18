using BLL.Interfaces;
using DTOs;
using DTOs.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Authorize(Roles = UserRoles.ExpiriencedUser)]
    [Authorize(Roles = UserRoles.User)]
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
        [Route("api/studyingMaterial/")]
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

        [Authorize(Roles = UserRoles.Admin)]
        [Authorize(Roles = UserRoles.ExpiriencedUser)]
        [HttpPost]
        [Route("api/studyingMaterial/")]
        public async Task<int> Create([FromBody] StudyingMaterialsDto dto)
        {
            _logger.LogInformation($"Create studying material." + DateTime.Now);
            return await _service.Create(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [Route("api/studyingMaterial/")]
        public async Task Update([FromBody] StudyingMaterialsDto dto)
        {
            _logger.LogInformation($"Update studying material." + DateTime.Now);
            await _service.Update(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        [Route("api/studyingMaterial/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete studying material with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}
