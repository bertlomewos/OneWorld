using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model
{
    public class ProductScreenShoot
    {
        [Key]
        public Guid ScreenShootId { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
