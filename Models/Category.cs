using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryImage { get; set; }
    }
}
