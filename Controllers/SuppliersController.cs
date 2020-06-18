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
    public class SuppliersController : ControllerBase
    {
        private readonly APIContext _context;

        public SuppliersController(APIContext context)
        {
            _context = context;

            //Ensures that the data is seeded
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        //Retrieve all suppliers and returns them together with an HTTP status code in Postman etc. as an array
        public async Task<IActionResult> GetSuppliers()
        {
            return Ok(await _context.Suppliers.ToArrayAsync());
        }

        [HttpGet("{id:int}")]
        //Retrieve a specific supplier and return it together with an HTTP status code in Postman etc.
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        //Posts a supplier and returns and returns an HTTP status code in Postman etc.
        public async Task<ActionResult<Supplier>> PostSupplier([FromBody]Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetSupplier",
                new { id = supplier.Id },
                supplier
            );
        }

        [HttpPut("{id}")]
        //Updates a specific supplier and returns an HTTP status code in Postman etc.
        //If an Id for a supplier that doesn't exist is used, you'll see the Bad Request error - 400
        //If an Id for a supplier that was deleted just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<IActionResult> PutSupplier([FromRoute] int id, [FromBody] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            _context.Entry(supplier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Suppliers.Find(id) == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        //Deletes a specific supplier and returns an HTTP status code in Postman etc.
        //If an Id for a supplier that was delete just a moment ago is used, you'll see the Not FOund error - 404
        public async Task<ActionResult<Supplier>> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }
    }
}