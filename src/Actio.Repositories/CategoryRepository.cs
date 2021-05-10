using Actio.Domain.Models;
using Actio.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public CategoryRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<Category> GetAsync(string name)
            => await Collection.AsQueryable()
            .FirstOrDefaultAsync(_ => _.Name == name.ToLowerInvariant());

        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection.AsQueryable().ToListAsync();

        private IMongoCollection<Category> Collection =>
            _mongoDatabase.GetCollection<Category>("Categories");
    }
}
