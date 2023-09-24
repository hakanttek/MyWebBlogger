using AutoMapper;
using MyWebBlogger.Contracts.Application.Posts;
using MyWebBlogger.Contracts.Application.Projects;
using MyWebBlogger.Domain.Posts;
using MyWebBlogger.Domain.Projects;

namespace MyWebBlogger.Application.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        { 
            CreateMap<Post, IPostDto>().ReverseMap();
            CreateMap<Project, IProjectDto>().ReverseMap();
        }
    }
}
