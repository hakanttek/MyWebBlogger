namespace MyWebBlogger.Contracts.Infrastructure.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity?>?> ReadAllAsync();
        Task<TEntity?> ReadByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
