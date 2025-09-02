using System.ComponentModel.DataAnnotations;

namespace proj_m.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Title is Required")]
        [MaxLength(400, ErrorMessage ="The title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Content is Required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The Author is Required")]
        [MaxLength(400, ErrorMessage = "The name cannot exceed 100 characters")]
        public string Author { get; set; }

        public string FeatureImagePath { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
    }
}
