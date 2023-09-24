using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebBlogger.Domain.Posts
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [StringLength(50)]
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Article { get; set; }
    }
}
