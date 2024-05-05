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

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            _shopDbContext.Products.Add(product);
            await _shopDbContext.SaveChangesAsync();

            return CreatedAtAction(
                    nameof(GetProduct), 
                    new {id = product.Id}, 
                    product
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody]Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try 
            {
                _shopDbContext.Entry(product).State = EntityState.Modified;
                await _shopDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!_shopDbContext.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _shopDbContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _shopDbContext.Products.Remove(product);
            await _shopDbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> DeleteMultiple([FromQuery] int[] ids)
        {
            var products = new List<Product>();

            foreach (var id in ids)
            {
                var product = await _shopDbContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }

            _shopDbContext.Products.RemoveRange(products);
            await _shopDbContext.SaveChangesAsync();

            return Ok(products);
        }

    }
}
