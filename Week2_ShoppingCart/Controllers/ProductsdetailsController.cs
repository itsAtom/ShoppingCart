using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2_ShoppingCart.Models;

namespace Week2_ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsdetailsController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public ProductsdetailsController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/Productsdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productsdetail>>> GetProductsdetails()
        {
          if (_context.Productsdetails == null)
          {
              return NotFound();
          }
            return await _context.Productsdetails.ToListAsync();
        }

        // GET: api/Productsdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productsdetail>> GetProductsdetail(Guid id)
        {
          if (_context.Productsdetails == null)
          {
              return NotFound();
          }
            var productsdetail = await _context.Productsdetails.FindAsync(id);

            if (productsdetail == null)
            {
                return NotFound();
            }

            return productsdetail;
        }

        // PUT: api/Productsdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsdetail(Guid id, Productsdetail productsdetail)
        {
            if (id != productsdetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(productsdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsdetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Productsdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productsdetail>> PostProductsdetail(Productsdetail productsdetail)
        {
          if (_context.Productsdetails == null)
          {
              return Problem("Entity set 'ShoppingCartContext.Productsdetails'  is null.");
          }
            _context.Productsdetails.Add(productsdetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductsdetailExists(productsdetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductsdetail", new { id = productsdetail.Id }, productsdetail);
        }

        // DELETE: api/Productsdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsdetail(Guid id)
        {
            if (_context.Productsdetails == null)
            {
                return NotFound();
            }
            var productsdetail = await _context.Productsdetails.FindAsync(id);
            if (productsdetail == null)
            {
                return NotFound();
            }

            _context.Productsdetails.Remove(productsdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductsdetailExists(Guid id)
        {
            return (_context.Productsdetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
