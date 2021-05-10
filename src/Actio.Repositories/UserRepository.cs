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
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        public async Task<User> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(_ => _.Id == id);

        public async Task<User> GetAsync(string email) => 
            await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(_ => _.Email == email.ToLowerInvariant());

        private IMongoCollection<User> Collection =>
            _mongoDatabase.GetCollection<User>("Users");
    }
}
