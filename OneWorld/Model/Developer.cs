using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model
{
    public class Developer
    {
        [Key]
        public required Guid UserId { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        public int? Age { get; set; }
        [MaxLength(10)]
        public string? Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
