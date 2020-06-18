using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rema1k.Models;
using Microsoft.EntityFrameworkCore;

namespace Rema1k.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly APIContext _context;

        public ProductsController(APIContext context)
        {
            _context = context;

            //Ensures that the data is seeded
            _context.Database.EnsureCreated();
        }
        [HttpGet]
        //Retrieve all products and returns them together with an HTTP status code in Postman etc. as an array
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        //Retrieve a specific product and return it together with an HTTP status code in Postman etc.
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        //Posts a product and returns and returns an HTTP status code in Postman etc.
        public async Task<ActionResult<Product>> PostProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product
            );
        }

        [HttpPut("{id}")]
        //Updates a specific product and returns an HTTP status code in Postman etc.
        //If an Id for a product that doesn't exist is used, you'll see the Bad Request error - 400
        //If an Id for a product that was deleted just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Products.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        //Deletes a specific product and returns an HTTP status code in Postman etc.
        //If an Id for a product that was delete just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}