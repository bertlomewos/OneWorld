using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneWorld.Data;
using OneWorld.Model.Dto;

namespace OneWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OneWorldDbContext context;
        public ProductController(OneWorldDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await context.Products.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet("by-developer/{developerId}")]
        public async Task<IActionResult> GetProductsByDeveloper(Guid developerId)
        {
            var products = await context.Products
                .Where(p => p.DeveloperUserId == developerId)
                .ToListAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is required");
            var newProduct = new Model.Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                DownloadUrl = productDto.DownloadUrl,
                WebsiteUrl = productDto.WebsiteUrl,
                IconUrl = productDto.IconUrl,
                DeveloperUserId = productDto.DeveloperUserId

            };
            context.Products.Add(newProduct);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Model.Dto.ProductDto productDto)
        {
            var existingProduct = await context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound();
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.DownloadUrl = productDto.DownloadUrl;
            existingProduct.WebsiteUrl = productDto.WebsiteUrl;
            existingProduct.IconUrl = productDto.IconUrl;
            context.Products.Update(existingProduct);
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await context.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound();
            context.Products.Remove(existingProduct);
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
