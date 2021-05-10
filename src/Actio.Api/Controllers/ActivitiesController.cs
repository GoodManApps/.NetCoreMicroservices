using Actio.Common.Commands;
using Actio.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Actio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ActivitiesController: ControllerBase
    {
        private readonly IBusClient _busClient;
        private readonly IActivityRepository _activitRepository;
        
        public ActivitiesController(IBusClient busClient,
            IActivityRepository activitRepository)
        {
            _busClient = busClient;
            _activitRepository = activitRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var activities = await _activitRepository
                .BrowseAsync(Guid.Parse(User.Identity.Name));

            return new JsonResult(activities
                .Select(x => new { x.Id, x.Name, x.Category, x.CreatedAt }));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var activity = await _activitRepository
                .GetAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            if (activity.UserId != Guid.Parse(User.Identity.Name))
            {
                return Unauthorized();
            }

            return new JsonResult(activity);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateActivity command )
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);

            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}
