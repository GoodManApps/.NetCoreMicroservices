using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Mongo
{
    public static class MongoExtensions
    {
        public static void AddMongoDb(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<MongoOptions>(configuration.GetSection("mongo"));

            serviceCollection.AddSingleton<MongoClient>(_ =>
            {
                var options = _.GetService<IOptions<MongoOptions>>();
                return new MongoClient(options.Value.ConnectionString);
            });
            
            serviceCollection.AddTransient<IMongoDatabase>(_ =>
            {
                var options = _.GetService<IOptions<MongoOptions>>();
                var client = _.GetService<MongoClient>();

                return client.GetDatabase(options.Value.Database);
            });

            serviceCollection.AddTransient<IDatabaseInitializer, MongoInitializer>();
            serviceCollection.AddTransient<IDatabaseSeeder, MongoSeeder>();
        }
    }
}
