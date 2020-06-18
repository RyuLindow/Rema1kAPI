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

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            return Ok(await _context.Suppliers.ToArrayAsync());
        }

        [HttpGet("{id:int}")]
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