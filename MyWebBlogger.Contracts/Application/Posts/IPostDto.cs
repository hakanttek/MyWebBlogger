namespace MyWebBlogger.Contracts.Application.Posts
{
    public interface IPostDto
    {
        int Id { get; set; }
        string? Title { get; set; }
        string? Description { get; set; }
        string? Author { get; set; }
        string? Article { get; set; }
    }
}