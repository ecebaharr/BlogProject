using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.DataAccess.Configurations;
using MongoDB.Driver;
using Microsoft.Extensions.Options;


namespace Blog.DataAccess.Contexts
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings, IMongoClient client)
        {
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Post> Posts => _database.GetCollection<Post>("Posts");
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
    }

}
