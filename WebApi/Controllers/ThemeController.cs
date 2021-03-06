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
    [Authorize]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly ILogger<ThemeController> _logger;
        private readonly IThemeService _service;

        public ThemeController(ILogger<ThemeController> logger, IThemeService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("api/course/{id}/theme/")]
        public async Task<IEnumerable<ThemeDto>> GetCourseThemes(int id)
        {
            _logger.LogInformation($"Getting all themes from course wiht id {id}." + DateTime.Now);
            var result = await _service.GetCourseThemes(id);
            return result;
        }

        [HttpGet]
        [Route("api/theme/{id}")]
        public async Task<ThemeDto> Get(int id)
        {
            _logger.LogInformation($"Start: Getting theme with id {id}." + DateTime.Now);
            var res = await _service.Get(id);
            _logger.LogInformation($"End: Getting theme with id {id}." + DateTime.Now);
            return res;
        }

        [Authorize(Roles = UserRoles.Admin + ", " + UserRoles.ExpiriencedUser)]
        [HttpPost]
        [Route("api/course/{id}/theme/")]
        public async Task<int> Create(int id, [FromBody] ThemeDto dto)
        {
            _logger.LogInformation($"Create theme." + DateTime.Now);
            return await _service.CreateThemeForCourse(dto, id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [Route("api/theme/")]
        public async Task Update([FromBody] ThemeDto dto)
        {
            _logger.LogInformation($"Update theme." + DateTime.Now);
            await _service.Update(dto);
        }

        [HttpPut]
        [Route("api/theme/updateRating")]
        public async Task UpdateRating([FromBody] ThemeRatingDto dto)
        {
            _logger.LogInformation($"Update theme." + DateTime.Now);
            await _service.UpdateRating(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        [Route("api/theme/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete theme with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}
