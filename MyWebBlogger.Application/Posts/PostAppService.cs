using AutoMapper;
using MyWebBlogger.Application.Common;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Contracts.Infrastructure.Common;
using MyWebBlogger.Domain.Posts;

namespace MyWebBlogger.Application.Posts
{
    public class PostAppService : CRUDAppService<Post, IPostDto>, IPostAppService
    {
        public PostAppService(IRepository<Post> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}