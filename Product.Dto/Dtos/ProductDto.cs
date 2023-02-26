using System.ComponentModel.DataAnnotations;

namespace Product.Dto.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Amount { get; set; }
        public string Picture { get; set; }
    }
}
