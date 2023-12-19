using System.ComponentModel.DataAnnotations;

namespace MVC2.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ProductImage { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
