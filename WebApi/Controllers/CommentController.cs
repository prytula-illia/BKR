using BLL.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class CommentController
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _service;

        public CommentController(ILogger<CommentController> logger, ICommentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("api/studyingMaterial/{id}/comment/")]
        public async Task<int> Create(int id, [FromBody] CommentDto dto)
        {
            _logger.LogInformation($"Create course." + DateTime.Now);
            return await _service.Create(dto);
        }
    }
}
