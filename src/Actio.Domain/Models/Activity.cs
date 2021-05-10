using Actio.Common.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Actio.Domain.Models
{
    public class Activity
    {
        [BsonId]
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Activity()
        {

        }

        [BsonConstructor]
        public Activity(Guid userId, string name, string category,
            string description, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_activity_name",
                    $"Activity name can not be empty");
            }

            Id = Guid.NewGuid();
            Name = name;
            Category = category;
            UserId = userId;
            CreatedAt = createdAt;
            Description = description;

        }

        public static Activity Create(Guid id, Guid userId, string name, string category,
            string description, DateTime createdAt)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("empty_activity_name",
                    $"Activity name can not be empty");
            }

            return new Activity()
            {
                Id = id,
                Category = category,
                CreatedAt = createdAt,
                Description = description,
                Name = name,
                UserId = userId
            };
        }

        //public Activity(Guid id, Category category, Guid userId, 
        //    string description, string name, DateTime createdAt)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        throw new ActioException("empty_activity_name",
        //            $"Activity name can not be empty");
        //    }

        //    Id = id;
        //    Name = name;
        //    Category = category.Name;
        //    UserId = userId;
        //    CreatedAt = createdAt;
        //    Description = description;

        //}
    }
}
