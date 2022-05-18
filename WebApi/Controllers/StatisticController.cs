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
        [Route("api/statistic/{id}")]
        public async Task<UserStatisticsDto> Get(int id)
        {
            _logger.LogInformation($"Get statistic with id {id}." + DateTime.Now);
            return await _service.Get(id);
        }

        [HttpPost]
        [Route("api/statistic/")]
        public async Task<int> Create([FromBody] UserStatisticsDto dto)
        {
            _logger.LogInformation($"Create statistic." + DateTime.Now);
            return await _service.Create(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
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
