using AutoMapper;
using MyWebBlogger.Application.Common;
using MyWebBlogger.Contracts.Application.Projects;
using MyWebBlogger.Contracts.Infrastructure.Common;
using MyWebBlogger.Domain.Projects;

namespace MyWebBlogger.Application.Projects
{
    public class ProjectAppService : CRUDAppService<Project, IProjectDto>, IProjectAppService
    {
        public ProjectAppService(IRepository<Project> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}