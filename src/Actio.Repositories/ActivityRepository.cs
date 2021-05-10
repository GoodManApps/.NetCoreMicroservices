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
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ActivityRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable()
            .FirstOrDefaultAsync(_ => _.Id == id);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid userId) => 
            await Collection.AsQueryable()
                .Where(_ => _.UserId == userId)
                .ToListAsync();

        private IMongoCollection<Activity> Collection =>
            _mongoDatabase.GetCollection<Activity>("Activities");
    }
}
