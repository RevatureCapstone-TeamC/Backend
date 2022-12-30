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
        public async Task<ActionResult<IEnumerable<Product>>> GetWishlistProducts(int? id)
        {
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
        }

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

/*
foreach (var item in query)
{
    Wishlist tempWishlist= new Wishlist();
    tempWishlist.fk_UserId = item.fkUserId;
    tempWishlist.fk_ProductId= item.fkProductId;
    if (tempWishlist.Products is not null)
    {
        tempWishlist.Products.ProductId = item.productId;
        tempWishlist.Products.ProductName = item.productName;
        tempWishlist.Products.ProductQuantity= item.productQuantity;
        tempWishlist.Products.ProductPrice = item.productPrice;
        tempWishlist.Products.ProductDescription = item.productDescription;
        tempWishlist.Products.ProductImage= item.productImage;
    }


    intersection.Add( tempWishlist );
}

 var query = (from w in wishlist
                         join p in products on w.fk_ProductId equals p.ProductId
                         select new
                         {
                             fkProductId = p.ProductId,
                             fkUserId = id,
                             productId = p.ProductId,
                             productName = p.ProductName,
                             productQuantity = p.ProductQuantity,
                             productDescription = p.ProductDescription,
                             productPrice = p.ProductPrice,
                             productImage = p.ProductImage
                         }
                        );


 List<Product> myProducts = new List<Product>();

            for (int i = 0; i < wishlist.Count; i++)
            {
                Console.WriteLine("----------------------------------------------------Wishlist id: " + wishlist[i].WishlistId);
                for (int j = 0; j < products.Count; j++)
                {
                    Console.WriteLine("----------------------------------------------------Product id: " + products[j].ProductId);
                    if (wishlist[i].fk_ProductId == products[j].ProductId)
                    {
                        var temp = products[j].ProductId;
                        products[j].ProductId = wishlist[i].WishlistId;

                        myProducts.Add(products[j]);
                        myProducts.ForEach(x => Console.WriteLine(x.ProductId));
                        products[j].ProductId = temp;
                    }
                }
            }
*/