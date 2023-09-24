namespace MyWebBlogger.Contracts.Application.Common
{
    public interface ICRUDAppService<TEntityDto> where TEntityDto : class
    {
        Task<int> CreateAsync(TEntityDto entityDto);
        Task<TEntityDto> ReadByIdAsync(int id);
        Task<IEnumerable<TEntityDto>> ReadAllAsync();
        Task UpdateByIdAsync(int id, TEntityDto entityDto);
        Task UpdateAsync(TEntityDto entityDto);
        Task DeleteByIdAsync(int id);
        Task DeleteAsync(TEntityDto entityDto);
    }
}