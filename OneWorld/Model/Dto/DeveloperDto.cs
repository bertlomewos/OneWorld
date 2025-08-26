using System.ComponentModel.DataAnnotations;

namespace OneWorld.Model.Dto
{
    public class DeveloperDto
    {
        public required Guid UserId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? GitHubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
