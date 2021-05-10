using Actio.Api.Controllers;
using Actio.Common.Commands;
using Actio.Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Actio.Api.Tests.Unit.Controllers
{
    public class ActivitiesControllerTests
    {
        [Fact]
        public async Task activities_post_should_acceptedAsync()
        {
            var busClientMoq = new Mock<IBusClient>();
            var activitRepositoryMoq = new Mock<IActivityRepository>();

            var ctrl = new ActivitiesController(
                busClientMoq.Object, 
                activitRepositoryMoq.Object);

            var userId = Guid.NewGuid();
            ctrl.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                     User = new ClaimsPrincipal(
                         new ClaimsIdentity(
                             new Claim[] { new Claim(ClaimTypes.Name, userId.ToString() )}, "test")
                         )
                }
            };

            var command = new CreateActivity()
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            var result = await ctrl.Post(command);

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"activities/{command.Id}");
        }
    }
}
