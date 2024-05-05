using DotNet8DemoWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _shopDbContext;

        public ProductsController(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
            _shopDbContext.Database.EnsureCreated();
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _shopDbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _shopDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("available")]
        public async Task<ActionResult> GetAvailableProducts()
        {
            var products = await _shopDbContext.Products.Where(x => x.IsAvailable == true).ToListAsync();
            return Ok(products);
        }
    }
}
