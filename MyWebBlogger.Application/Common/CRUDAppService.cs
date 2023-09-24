using AutoMapper;
using MyWebBlogger.Contracts.Application.Common;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Contracts.Infrastructure.Common;

namespace MyWebBlogger.Application.Common
{
    public class CRUDAppService<T, TDto> : ICRUDAppService<TDto> where T : class where TDto : class
    {
        private readonly IRepository<T> _repository;
        private readonly IMapper _mapper;

        public CRUDAppService(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TDto> ReadByIdAsync(int id)
        {
            var entity = await _repository.ReadByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<IEnumerable<TDto>> ReadAllAsync()
        {
            var entities = await _repository.ReadAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<int> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task UpdateByIdAsync(int id, TDto dto)
        {
            var existingEntity = await _repository.ReadByIdAsync(id);

            if (existingEntity == null)
            {
                // Handle not found scenario
                return;
            }

            _mapper.Map(dto, existingEntity);
            await _repository.UpdateAsync(existingEntity);
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<T>(dto);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            var entity = await _repository.ReadByIdAsync(id);

            if (entity == null)
            {
                // Handle not found scenario
                return;
            }

            await _repository.DeleteAsync(entity);
        }
        public virtual async Task DeleteAsync(TDto dto)
        {
            var entitiy = _mapper.Map<T>(dto);
            await _repository.DeleteAsync(entitiy);
        }
    }
}
