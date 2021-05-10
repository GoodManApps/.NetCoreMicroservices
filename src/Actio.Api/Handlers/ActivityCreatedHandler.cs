using Actio.Common.Events;
using Actio.Domain.Models;
using Actio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _repository;

        public ActivityCreatedHandler(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(ActivityCreated @event)
        {
            await _repository.AddAsync(
                Activity.Create(@event.Id, @event.UserId,
                @event.Name, @event.Category, 
                @event.Description, @event.CreatedAt)
                );

            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
