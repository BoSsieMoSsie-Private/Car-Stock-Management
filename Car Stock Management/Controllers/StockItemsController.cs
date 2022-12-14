using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Car_Stock_Management.Data;
using Car_Stock_Management.Models;

namespace Car_Stock_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemsController : ControllerBase
    {
        private readonly CMSContext _context;

        public StockItemsController(CMSContext context)
        {
            _context = context;
        }

        // GET: api/StockItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> GetStockItems()
        {
            return await _context.StockItems.ToListAsync();
        }

        // GET: api/StockItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockItem>> GetStockItem(int id)
        {
            var stockItem = await _context.StockItems.FindAsync(id);

            if (stockItem == null)
            {
                return NotFound();
            }

            return stockItem;
        }

        // PUT: api/StockItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItem(int id, StockItem stockItem)
        {
            if (id != stockItem.StockItemId)
            {
                return BadRequest();
            }

            _context.Entry(stockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
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

        // POST: api/StockItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockItem>> PostStockItem(StockItem stockItem)
        {
            _context.StockItems.Add(stockItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockItemExists(stockItem.StockItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStockItem", new { id = stockItem.StockItemId }, stockItem);
        }

        // DELETE: api/StockItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockItem(int id)
        {
            var stockItem = await _context.StockItems.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            _context.StockItems.Remove(stockItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockItemExists(int id)
        {
            return _context.StockItems.Any(e => e.StockItemId == id);
        }
    }
}
