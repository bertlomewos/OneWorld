using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneWorld.Data;

namespace OneWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OneWorldDbContext _logger;
        public ProductController(OneWorldDbContext logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
                    var products = await _logger.Products
            .Include(p => p.ProductDevelopers)
                .ThenInclude(pd => pd.Developer)
            .ToListAsync();
                    return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _logger.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Model.Dto.ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is required");
            var newProduct = new Model.Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                DownloadUrl = productDto.DownloadUrl,
                WebsiteUrl = productDto.WebsiteUrl,
                IconUrl = productDto.IconUrl
            };
            _logger.Products.Add(newProduct);
            await _logger.SaveChangesAsync();
            var productDeveloper = new Model.ProductDeveloper
            {
                ProductId = newProduct.Id,
                DeveloperId = productDto.DeveloperId
            };
            _logger.ProductDevelopers.Add(productDeveloper);
            await _logger.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Model.Dto.ProductDto productDto)
        {
            var existingProduct = await _logger.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound();
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.DownloadUrl = productDto.DownloadUrl;
            existingProduct.WebsiteUrl = productDto.WebsiteUrl;
            existingProduct.IconUrl = productDto.IconUrl;
            _logger.Products.Update(existingProduct);
            await _logger.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _logger.Products.FindAsync(id);
            if (existingProduct == null)
                return NotFound();
            _logger.Products.Remove(existingProduct);
            await _logger.SaveChangesAsync();
            return NoContent();
        }

    }
}
