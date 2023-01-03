using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using ECommerce.Models;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CommerceContext _context;

        public CartController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            if (_context.Cart == null)
            {
                return NotFound();
            }
            return await _context.Cart.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetCart(int? id)
        {
            if (_context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.Where(x => x.fk_UserID == id).ToListAsync();
            var products = await _context.Products.ToListAsync();

            List<Product> intersection = products.IntersectBy(cart.Select(x => x.fk_ProductID), (y) => y.ProductId).ToList();
            List<Product> updatedList = new List<Product>();

            foreach (var product in intersection)
            {
                foreach (var item in cart)
                {
                    if (product.ProductId == item.fk_ProductID)
                    {
                        var temp = product;
                        temp.ProductId = item.CartId;
                        updatedList.Add(temp);
                    }
                }
            }

            if (updatedList == null)
            {
                return NotFound();
            }

            return updatedList;
            /*
            if (_context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.Where(x => x.fk_UserId == id).ToListAsync();
            var products = await _context.Products.ToListAsync();

           


            List<Product> intersection = products.IntersectBy(wishlist.Select(x => x.fk_ProductId), (y) => y.ProductId).ToList();
            List<Product> updatedList= new List<Product>();
            foreach (var product in intersection)
            {
                foreach(var item in wishlist)
                {
                    if (product.ProductId == item.fk_ProductId)
                    {
                        var temp = product;
                        temp.ProductId = item.WishlistId;
                        updatedList.Add(temp);
                    }
                }
            }
           
            if (intersection == null)
            {
                return NotFound();
            }
            return intersection;
             */
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int? id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            if (_context.Cart == null)
            {
                return Problem("Entity set 'ECommerceAPIContext.Cart'  is null.");
            }
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int? id)
        {
            if (_context.Cart == null)
            {
                return NotFound();
            }
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartExists(int? id)
        {
            return (_context.Cart?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}