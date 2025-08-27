using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model.Dto
{
    public class ProductDto
    {
        public int DeveloperId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? DownloadUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? IconUrl { get; set; }
    }
}
