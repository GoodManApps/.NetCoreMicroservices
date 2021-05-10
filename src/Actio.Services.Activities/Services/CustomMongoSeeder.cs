using Actio.Common.Mongo;
using Actio.Domain.Models;
using Actio.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;

        public CustomMongoSeeder(IMongoDatabase mongoDatabase,
            ICategoryRepository categoryRepository): base(mongoDatabase)
        {
            _categoryRepository = categoryRepository;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work", "sport", "hobby"
            };
            await Task.WhenAll(
                categories.Select(c =>
                _categoryRepository.AddAsync(new Category(c)))
                );
        }
    }
}
