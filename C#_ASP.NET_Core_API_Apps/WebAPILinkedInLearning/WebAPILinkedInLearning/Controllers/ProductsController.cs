using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using WebAPILinkedInLearning.Models;

namespace WebAPILinkedInLearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        public ProductsController (ShopDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/alt")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAlt([FromQuery] ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            if (queryParameters.MinPrice != null)
            {
                products = products
                    .Where(p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products
                    .Where(p => p.Price <= queryParameters.MaxPrice.Value);
            }

            products = products
                .Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);
            var products2 = await _context.Products.ToListAsync();
            return Ok(await products.ToListAsync());
        }

        [HttpGet]
        [Route("/")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) { 
                return NotFound(); 
            }
            return Ok(product);  
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new {id = product.Id},
                product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(
            int id, [FromBody] Product product)
        {
            if (id != product.Id) { 
                return BadRequest();
            }
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound(id);
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }


        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultopleProducts([FromQuery] int[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                {
                    return NotFound(id);
                }
                products.Add(product);

            }
            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            return Ok(products);
        }

    }
}
