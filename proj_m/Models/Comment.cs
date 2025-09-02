using System.ComponentModel.DataAnnotations;

namespace proj_m.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The UserName is Required")]
        [MaxLength(400, ErrorMessage = "The UserName cannot exceed 100 characters")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
