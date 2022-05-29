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
    public class StatisticController : ControllerBase
    {
        private readonly ILogger<StatisticController> _logger;
        private readonly IStatisticService _service;

        public StatisticController(ILogger<StatisticController> logger, IStatisticService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("api/statistic/")]
        public IEnumerable<UserStatisticsDto> GetAll()
        {
            _logger.LogInformation("Getting all statistics: " + DateTime.Now);
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/statistic/{userName}")]
        public UserStatisticsDto Get(string userName)
        {
            _logger.LogInformation($"Get statistic for user {userName}." + DateTime.Now);
            return _service.GetByName(userName);
        }


        [HttpGet]
        [Route("api/statistic/{statisticId}/themesRaterForCourse/{courseId}")]
        public async Task<float> GetThemesReateForCourse(int statisticId, int courseId)
        {
            _logger.LogInformation("Get statistic for course: " + DateTime.Now);
            return await _service.GetThemesFinishedRateForCourse(statisticId, courseId);
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("api/statistic/")]
        public async Task<int> Create([FromBody] UserStatisticsDto dto)
        {
            _logger.LogInformation($"Create statistic." + DateTime.Now);
            return await _service.Create(dto);
        }

        [HttpPut]
        [Route("api/statistic/")]
        public async Task Update([FromBody] UserStatisticsDto dto)
        {
            _logger.LogInformation($"Update statistic." + DateTime.Now);
            await _service.Update(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        [Route("api/statistic/{id}")]
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Delete statistic with id {id}." + DateTime.Now);
            await _service.Delete(id);
        }
    }
}
