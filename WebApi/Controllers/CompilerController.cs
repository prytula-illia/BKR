using BLL.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class CompilerController : ControllerBase
    {
        private readonly ILogger<CompilerController> _logger;
        private readonly IDotNetCompilerService _service;

        public CompilerController(ILogger<CompilerController> logger, IDotNetCompilerService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("api/compiler/")]
        public CodeDto Create([FromBody] CodeDto code)
        {
            _logger.LogInformation($"Compile code." + DateTime.Now);
            return _service.Compile(code);
        }
    }
}
