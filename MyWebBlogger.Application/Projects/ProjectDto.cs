using MyWebBlogger.Contracts.Application.Projects;

namespace MyWebBlogger.Application.Projects
{
    public class ProjectDto : IProjectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? URI { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? InstitutionsName { get; set; }
        public string? InstitutionURI { get; set; }
    }
}
