using Actio.Domain.Models;
using Actio.Domain.Repositories;
using Actio.Services.Activities.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Actio.Services.Activities.Tests.Unit.Services
{
    public class ActivityServiceTests
    {
        [Fact]
        public async Task Activity_service_add_should_succeed()
        {
            var category = "test";

            var activitRepositoryMoq = new Mock<IActivityRepository>();
            var categoryRepositoryMoq = new Mock<ICategoryRepository>();

            categoryRepositoryMoq.Setup(x => x.GetAsync(category))
                .ReturnsAsync(new Category(category));

            var activityService = new ActivityService(
                activitRepositoryMoq.Object,
                categoryRepositoryMoq.Object);

            var id = Guid.NewGuid();
            await activityService.AddAsync(id, Guid.NewGuid(), category, "asas", "", DateTime.UtcNow);

            categoryRepositoryMoq.Verify(x => x.GetAsync(category), Times.Once);
            activitRepositoryMoq.Verify(x => x.AddAsync(It.IsAny<Activity>()), Times.Once);
        }
    }
}
