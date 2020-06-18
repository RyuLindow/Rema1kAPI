using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rema1k.Models;

namespace Rema1k.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly APIContext _context;

        public CategoriesController(APIContext context)
        {
            _context = context;

            //Ensures that the data is seeded
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        //Retrieve all categories and returns them together with an HTTP status code in Postman etc. as an array
        public async Task<IActionResult> GetCategories() {
            return Ok(await _context.Categories.ToArrayAsync());
        }

        [HttpGet("{id:int}")]
        //Retrieve a specific category and return it together with an HTTP status code in Postman etc.
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        //Posts a category and returns and returns an HTTP status code in Postman etc.
        public async Task<ActionResult<Category>> PostCategory([FromBody]Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCategory",
                new { id = category.Id },
                category
            );
        }

        [HttpPut("{id}")]
        //Updates a specific category and returns an HTTP status code in Postman etc.
        //If an Id for a category that doesn't exist is used, you'll see the Bad Request error - 400
        //If an Id for a category that was deleted just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (id != category.Id) {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Categories.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        //Deletes a specific category and returns an HTTP status code in Postman etc.
        //If an Id for a category that was delete just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}