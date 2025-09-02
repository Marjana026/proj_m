using System.ComponentModel.DataAnnotations;

namespace proj_m.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Category Name is Rqeuired")]
        [MaxLength(100, ErrorMessage ="Category Name Cannot Exceed 200 characters")]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
