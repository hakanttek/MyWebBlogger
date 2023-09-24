namespace MyWebBlogger.Contracts.Application.Projects
{
    public interface IProjectDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? URI { get; set; }
        public string? InstitutionsName { get; set; }
        public string? InstitutionURI { get; set; }
    }
}
