using ECommerce.Data;
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
        private CommerceContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(CommerceContext context, ILogger<ProductController> logger)
        {
            this._context = context;
            this._logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOne(int id)
        {
            _logger.LogInformation("api/product/{id} triggered");
         
            /* return Ok(await _repo.GetProductByIdAsync(id)); */
            var product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound();

            return product;
            /* _logger.LogInformation("api/product/{id} completed successfully"); */
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            _logger.LogInformation("api/product triggered");
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
            _logger.LogInformation("PATCH api/product triggered");
            List<Product> products = new List<Product>();
            try
            {
                foreach(Product item in purchaseProducts)
                {
                    /* Product tmp = await _repo.GetProductByIdAsync(item.id); */
                    Product tmp = await _context.Products.FindAsync(item.ProductId);
                    if ((tmp.ProductQuantity - item.ProductQuantity) >= 0)
                    {
                        /* await _repo.ReduceInventoryByIdAsync(item.ProductId, item.ProductQuantity); */
                        // TODO : Implement some method to update the stock based on purchased stuff in cart

                        /* products.Add(await _repo.GetProductByIdAsync(item.id)); */
                        products.Add(await _context.Products.FindAsync(item.ProductId));
                    }
                    else
                    {
                        throw new Exception("Insuffecient inventory.");
                    }
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

    }
}
