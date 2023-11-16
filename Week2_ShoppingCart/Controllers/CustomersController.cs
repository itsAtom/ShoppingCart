using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week2_ShoppingCart.Models;

namespace Week2_ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ShoppingCartContext _context;

        public CustomersController(ShoppingCartContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        /*[Authorize(AuthenticationSchemes = "Basic")]*/
        //[Authorize]
        public async Task<IActionResult> GetCustomers([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ident = User.Identity as ClaimsIdentity;
            var currentLoggeedInUserId = ident.Claims.FirstOrDefault
            (c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (currentLoggeedInUserId != id.ToString())
            {
                // Not Authorized
                return BadRequest("You are not authorized!");
            }
            var customers = await _context.Customers.SingleOrDefaultAsync
            (m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          var guid = System.Guid.NewGuid();
          if (_context.Customers == null)
          {
              return Problem("Entity set 'ShoppingCartContext.Customers'  is null.");
          }
          if (_context.Customers.Any(x => x.Email == customer.Email))
            {
                ModelState.AddModelError("email", "User with mail id already exists!");
                return BadRequest(ModelState);
            }
          customer.Id = guid;
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(Guid id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
