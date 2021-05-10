using System;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public string Category { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime CreatedAt { get; }
        
        protected ActivityCreated()
        {
        }

        public ActivityCreated(Guid id, Guid userId, string name, string category, string description, DateTime createdAt)
        {
            this.Id = id;
            this.UserId = userId;
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.CreatedAt = createdAt;

        }
    }
}