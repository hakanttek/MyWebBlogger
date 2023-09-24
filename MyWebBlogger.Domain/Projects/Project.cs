using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebBlogger.Domain.Projects
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? URI { get; set; }

        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string? InstitutionsName { get; set; }
        [StringLength(50)]
        public string? InstitutionURI { get; set; }
    }
}
