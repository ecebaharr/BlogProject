using Blog.Core.Entities;
using Blog.DataAccess.Contexts;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repositories
{
    public class PostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostRepository(MongoDbContext context)
        {
            _posts = context.Posts;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _posts.Find(_ => true).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(string id)
        {
            return await _posts.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
        }

        public async Task UpdateAsync(string id, Post updatedPost)
        {
            await _posts.ReplaceOneAsync(p => p.Id == id, updatedPost);
        }

        public async Task DeleteAsync(string id)
        {
            await _posts.DeleteOneAsync(p => p.Id == id);
        }
    }
}
