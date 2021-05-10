using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    public class MongoInitializer : IDatabaseInitializer
    {
        private bool _isInitialized;
        private readonly bool _seed;
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSeeder _databaseSeeder;

        public MongoInitializer(IMongoDatabase mongoDatabase,
            IDatabaseSeeder databaseSeeder,
            IOptions<MongoOptions> options)
        {
            _database = mongoDatabase;
            _databaseSeeder = databaseSeeder;
            _seed = options.Value.Seed;
        }

        public async Task InitializeAsync()
        {
            if (_isInitialized)
            {
                return;
            }

            RegisterConventions();

            _isInitialized = true;

            if (!_seed)
            {
                return;
            }

            await _databaseSeeder.SeedAsync();
        }

        private void RegisterConventions()
        {
            ConventionRegistry.Register("ActioConventions", new MongoConvention(), x => true);
        }
    }
}
