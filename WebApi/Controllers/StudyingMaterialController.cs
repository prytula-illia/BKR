using BLL.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
        [Route("api/studyingMaterials")]
        public IEnumerable<StudyingMaterialsDto> GetAll()
        {
            _logger.LogInformation("Getting all studying materials: " + DateTime.Now);
            return _service.GetAllStudyingMaterials();
        }
    }
}
