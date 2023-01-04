//using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /* private readonly IRepository _repo; */
        private readonly CommerceContext _context;

        public ProductController(CommerceContext context)
        {
            this._context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOne(int id)
        {
            /* _logger.LogInformation("api/product/{id} triggered"); */
         
            /* return Ok(await _repo.GetProductByIdAsync(id)); */
            var product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound();

            return product;
            /* _logger.LogInformation("api/product/{id} completed successfully"); */
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            /* _logger.LogInformation("api/product triggered"); */
            try
            {
                /* return Ok(await _repo.GetAllProductsAsync());
                _logger.LogInformation("api/product completed successfully"); */
                return await _context.Products.ToListAsync();
            }
            catch
            {
                return BadRequest();
                /* _logger.LogWarning("api/product completed with errors"); */
            }
        }

        [HttpPatch]
        public async Task<ActionResult<Product[]>> Purchase([FromBody] IEnumerable<Product> purchaseProducts)
        {
            /* _logger.LogInformation("PATCH api/product triggered"); */
            List<Product> products = new List<Product>();
            Console.WriteLine(purchaseProducts.Count());
            try
            {
                foreach (Product item in purchaseProducts)
                {
                    var tmp = _context.Products.SingleOrDefault(p =>
                        p.ProductName == item.ProductName);
                    if ((tmp.ProductQuantity - item.ProductQuantity) >= 0)
                    {
                        //All Good - Making sure all items are in stock first
                    }
                    else
                    {
                        throw new Exception("Insuffecient inventory.");
                    }
                    await _context.SaveChangesAsync();
                }


                foreach (Product item in purchaseProducts)
                {
                    /* Product tmp = await _repo.GetProductByIdAsync(item.id); */
                    Console.WriteLine("=================================== {0}", item.ProductName);
                    var tmp = _context.Products.SingleOrDefault(p =>
                        p.ProductName == item.ProductName);
                    if ((tmp.ProductQuantity - item.ProductQuantity) >= 0)
                    {
                        /* await _repo.ReduceInventoryByIdAsync(item.ProductId, item.ProductQuantity); */
                        tmp.ProductQuantity -= item.ProductQuantity;
                        /* products.Add(await _repo.GetProductByIdAsync(item.id)); */
                        products.Add(await _context.Products.FindAsync(tmp.ProductId));
                    }
                    else
                    {
                        throw new Exception("Insuffecient inventory.");
                    }
                        await _context.SaveChangesAsync();
                }
                return Ok(products);
                /* _logger.LogInformation("PATCH api/product completed successfully"); */
            }
            catch
            {
                return BadRequest();
                /* _logger.LogWarning("PATCH api/product completed with errors"); */
            }
        }
        /*
        public async Task<ActionResult<Product[]>> Purchase(IEnumerable<Product> purchaseProducts)
        {

            Console.WriteLine("------------------------ " + purchaseProducts.Count());
            List<Product> products = new List<Product>();
            try
            {
                Console.WriteLine("------------------------ Inside try block");
                foreach (Product item in purchaseProducts)
                {
                    Console.WriteLine("------------------------ foreach " + item.ProductName, item.ProductId);
                    var tmp = _context.Products.SingleOrDefault(p => 
                        p.ProductName == item.ProductName);
                    if ((tmp.ProductQuantity - 1) >= 0)
                    {
                        tmp.ProductQuantity -= 1;
                        await _context.SaveChangesAsync();
                        /* products.Add(await _repo.GetProductByIdAsync(item.id)); 
                        products.Add(await _context.Products.FindAsync(item.ProductId));
                    }
                    else
                    {
                        throw new Exception("Insuffecient inventory.");
                    }
                }
                return Ok(products);
            }
            catch
            {
                return BadRequest();
            }
        }
         */

    }
}
