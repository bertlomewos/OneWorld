using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model
{
    public class Product 
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? DownloadUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? IconUrl { get; set; }
        public string? bannerUrl { get; set; }
        [Required]
        public Guid DeveloperUserId { get; set; }
        public virtual Developer DeveloperUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

