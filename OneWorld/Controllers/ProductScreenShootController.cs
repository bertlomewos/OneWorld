using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneWorld.Model.Dto;

namespace OneWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductScreenShootController : ControllerBase
    {
        private readonly Data.OneWorldDbContext context;
        public ProductScreenShootController(Data.OneWorldDbContext context)
        {
            this.context = context;
        }

        #region // Get Product Screen Shoots by Product ID and All Product Screen Shoots
        [HttpGet("{productID}")]
        public async Task<IActionResult> GetProductScreenShootsByProductId(Guid productID)
        {
            var screenShoots = await context.ProductScreenShoots
                .Where(pss => pss.ProductId == productID)
                .ToListAsync();
            if (screenShoots == null || screenShoots.Count == 0)
                return NotFound();
            return Ok(screenShoots);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductScreenShoot(ProductScreenShootDto screenShootDto)
        {
           //var screenShoots = await context.Products.Where(p => p.Id == screenShootDto.ProductId).ToListAsync();
           // if (screenShoots.Count > 3)
           //     return NotFound("You have exceeded max limit");
            if (screenShootDto == null)
                return BadRequest("Screen shoot data is required");
            var newScreenShoot = new Model.ProductScreenShoot
            {
                ImageUrl = screenShootDto.ImageUrl,
                ProductId = screenShootDto.ProductId,
            };
            context.ProductScreenShoots.Add(newScreenShoot);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateProductScreenShoot), new { id = newScreenShoot.ScreenShootId }, newScreenShoot);
        }
        #endregion

        #region // Update and Delete Product Screen Shoot
        [HttpPut("{screenShootId}")]
        public async Task<IActionResult> UpdateProductScreenShoot(Guid screenShootId, Model.Dto.ProductScreenShootDto screenShootDto)
        {
            var existingScreenShoot = await context.ProductScreenShoots.FindAsync(screenShootId);
            if (existingScreenShoot == null)
                return NotFound();
            existingScreenShoot.ImageUrl = screenShootDto.ImageUrl;
            context.ProductScreenShoots.Update(existingScreenShoot);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{screenShootId}")]
        public async Task<IActionResult> DeleteProductScreenShoot(Guid screenShootId)
        {
            var screenShoot = await context.ProductScreenShoots.FindAsync(screenShootId);
            if (screenShoot == null)
                return NotFound();
            context.ProductScreenShoots.Remove(screenShoot);
            await context.SaveChangesAsync();
            return NoContent();
        }
        #endregion

    }
}
