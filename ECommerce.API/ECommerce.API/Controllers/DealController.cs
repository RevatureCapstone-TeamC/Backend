
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealController : ControllerBase
{
    private readonly CommerceContext _context;

    public DealController(CommerceContext context) {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Deal>>> GetDeals(){
        try {
            return await _context.Deals.ToListAsync();
        }
        catch {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Deal>> GetDeal(int dealId){
        var deal = await _context.Deals.FindAsync(dealId);

        if (deal is null) return NotFound();

        
        return deal;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeal(Deal deal){
        deal.DealId = 0;

        //Product has to be valid
        ProductController tmpPC = new(_context);
        if (tmpPC.GetOne((int)deal.Product_Id).Status is Microsoft.AspNetCore.Mvc.NotFoundResult)
            return BadRequest("This product does not exist");
        
        //Price can't be 0 or less
        if (deal.SalePrice <= 0)
            return BadRequest("Sale price can't be $0.0 or lower");

        _context.Deals.Add(deal);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDeal(Deal deal){
        _context.Entry(deal).State = EntityState.Modified;

        try {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException){
            if (!_context.Deals.Any(e => e.DealId == deal.DealId)) 
                return NotFound();
            else throw;
        }

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDeal(int id){
        var deal = await _context.Deals.FindAsync(id);
        
        // ! Deal isn't in there
        if (deal is null)
            return NotFound();

        _context.Deals.Remove(deal);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}