using Microsoft.EntityFrameworkCore;
using MyWebBlogger.Contracts.Infrastructure.Common;
using MyWebBlogger.Domain.Projects;
using MyWebBlogger.Infrastructure.Data;

namespace MyWebBlogger.Infrastructure.Projects
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Project project)
        {
            _dbContext.Projects.Add(project);
            await _dbContext.SaveChangesAsync();
            return project.Id;
        }

        public async Task<IEnumerable<Project?>?> ReadAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project?> ReadByIdAsync(int id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task UpdateAsync(Project project)
        {
            _dbContext.Entry(project).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var project = await _dbContext.Projects.FindAsync(id);
            if(project is not null)
            {
                _dbContext.Projects.Remove(project);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Project project)
        {
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }
    }
}
