using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneWorld.Data;
using OneWorld.Model;
using OneWorld.Model.Dto;

namespace OneWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly OneWorldDbContext context;
        public DeveloperController(OneWorldDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopers()
        {
            return Ok(await context.Developers.ToListAsync());
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<Developer>> GetUser(Guid userId)
        {
            var developer = await context.Developers.FirstOrDefaultAsync(u => u.UserId == userId);

            if (developer == null)
                return NotFound();

            return Ok(developer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDeveloper(DeveloperDto developerDto)
        {
            if (developerDto == null)
                return BadRequest("User data is required");

            var existingUser = new Developer
            {
                UserId = developerDto.UserId,
                Email = developerDto.Email,
                Password = developerDto.Password,
                ProfilePictureUrl = developerDto.ProfilePictureUrl,
                GitHubUrl = developerDto.GitHubUrl,
                LinkedInUrl = developerDto.LinkedInUrl,
                FirstName = developerDto.FirstName,
                LastName = developerDto.LastName,
                Age = developerDto.Age,
                Gender = developerDto.Gender
            };
            context.Developers.Add(existingUser);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { userId = existingUser.UserId }, existingUser);
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateDeveloper(Guid userId, DeveloperDto developerDto)
        {
            var existingUser = await context.Developers.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existingUser == null)
                return NotFound();
            existingUser.Email = developerDto.Email;
            existingUser.Password = developerDto.Password;
            existingUser.ProfilePictureUrl = developerDto.ProfilePictureUrl;
            existingUser.GitHubUrl = developerDto.GitHubUrl;
            existingUser.LinkedInUrl = developerDto.LinkedInUrl;
            existingUser.FirstName = developerDto.FirstName;
            existingUser.LastName = developerDto.LastName;
            existingUser.Age = developerDto.Age;
            existingUser.Gender = developerDto.Gender;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteDeveloper(Guid userId)
        {
            var existingUser = await context.Developers.FirstOrDefaultAsync(u => u.UserId == userId);
            if (existingUser == null)
                return NotFound();
            context.Developers.Remove(existingUser);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
