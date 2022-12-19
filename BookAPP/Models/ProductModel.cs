using System.ComponentModel.DataAnnotations;

namespace BookAPP.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; } //= null!;
        public string Category { get; set; } //= null!;
        public double Price { get; set; }
    }
}
