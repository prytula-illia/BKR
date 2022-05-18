﻿using BLL.Interfaces;
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
        [Route("api/theme/")]
        public IEnumerable<ThemeDto> GetAll()
        {
            _logger.LogInformation("Getting all themes: " + DateTime.Now);
            return _service.GetAll();
        }

        [HttpGet]
        [Route("api/theme/{id}")]
        public async Task<ThemeDto> Get(int id)
        {
            _logger.LogInformation($"Get theme with id {id}." + DateTime.Now);
            return await _service.Get(id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [Authorize(Roles = UserRoles.ExpiriencedUser)]
        [HttpPost]
        [Route("api/theme/")]
        public async Task<int> Create([FromBody] ThemeDto dto)
        {
            _logger.LogInformation($"Create theme." + DateTime.Now);
            return await _service.Create(dto);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [Route("api/theme/")]
        public async Task Update([FromBody] ThemeDto dto)
        {
            _logger.LogInformation($"Update theme." + DateTime.Now);
            await _service.Update(dto);
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
