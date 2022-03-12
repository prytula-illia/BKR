using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearnModuleController : ControllerBase
    {
        private readonly ILogger<LearnModuleController> _logger;
        private ILearnModuleService _service;

        public LearnModuleController(ILogger<LearnModuleController> logger, ILearnModuleService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<LearnModuleDto> Get()
        {
            _logger.LogInformation("Getting all learn modules: " + DateTime.Now);
            return _service.GetAllLearnModules();
        }
    }
}
