using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model.Dto
{
    public class ProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? DownloadUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? IconUrl { get; set; }
        public string? bannerUrl { get; set; }
        public Guid DeveloperUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
