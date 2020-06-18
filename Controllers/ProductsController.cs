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
        //Retrieve all products and returns them together with an HTTP status code in the browser/Postman etc. as an array
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        //Retrieve a specific product and return it together with an HTTP status code in the browser/Postman etc. as an array
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        /*
        [HttpPost]

        [HttpPut("{id}")]

        [HttpDelete("{id}")]
        */
    }
}