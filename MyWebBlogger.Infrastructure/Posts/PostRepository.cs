using Microsoft.EntityFrameworkCore;
using MyWebBlogger.Contracts.Infrastructure.Common;
using MyWebBlogger.Domain.Posts;
using MyWebBlogger.Infrastructure.Data;

namespace MyWebBlogger.Infrastructure.Posts
{
    public class PostRepository : IRepository<Post>
    {
        private readonly ApplicationDbContext _dbContext;
        
        public PostRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post.Id;
        }

        public async Task<IEnumerable<Post?>?> ReadAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post?> ReadByIdAsync(int id)
        {
            return await _dbContext.Posts.FindAsync(id);
        }

        public async Task UpdateAsync(Post post)
        {
            _dbContext.Entry(post).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Post post)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
