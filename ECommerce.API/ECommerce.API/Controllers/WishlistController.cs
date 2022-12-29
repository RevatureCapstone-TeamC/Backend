using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
using System.Net.WebSockets;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly CommerceContext _context;

        public WishlistController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }

            return await _context.Wishlist.ToListAsync();
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlistProducts(int? id)
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }

            var wishlist = await _context.Wishlist.Where(x => x.fk_UserId == id).ToListAsync();
            var products = await _context.Products.ToListAsync();
            

            //var intersection = wishlist.IntersectBy(products.Select(x => x.ProductId), (y) => y.fk_ProductId).ToList();
            //intersection.ForEach(x => x.Products = products.Where(y => y.ProductId == x.fk_ProductId));

            var intersection = (from w in wishlist
                                join p in products on w.fk_ProductId equals p.ProductId
                                select new Wishlist
                                {
                                    fk_ProductId = p.ProductId,
                                    fk_UserId = id,
                                    Products = new Product (p.ProductId, p.ProductName, p.ProductQuantity, p.ProductPrice, p.ProductDescription, p.ProductImage)
                                }
                                ).ToList();

            if (wishlist == null)
            {
                return NotFound();
            }

            return intersection;
        }
        /*
        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlistId(int? id, Wishlist wishlist)
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }

            //var wishlists = await _context.Wishlist.Where(x => x.fk_UserId == id).ToListAsync();
            var wishlistItems = await _context.Wishlist.Where(x => (x.fk_UserId == wishlist.fk_UserId && x.fk_ProductId == wishlist.fk_ProductId)).ToListAsync();
            //var products = await _context.Products.ToListAsync();

            //var intersection = wishlist.IntersectBy(products.Select(x => x.ProductId), (y) => y.fk_ProductId).ToList();

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlistItems;
        }
        */
        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int? id, Wishlist wishlist)
        {
            if (id != wishlist.WishlistId)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            if (_context.Wishlist == null)
            {
                return Problem("Entity set 'ECommerceAPIContext.Wishlist'  is null.");
            }
            _context.Wishlist.Add(wishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.WishlistId }, wishlist);
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int? id)
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishlistExists(int? id)
        {
            return (_context.Wishlist?.Any(e => e.WishlistId == id)).GetValueOrDefault();
        }
    }
}
