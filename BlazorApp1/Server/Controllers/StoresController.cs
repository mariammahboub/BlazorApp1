using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase { 
        private readonly ApplicationDbContext _context;

        public StoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.Include(s => s.CustomerLocations).ToListAsync();
        }

        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _context.Stores.Include(s => s.CustomerLocations).FirstOrDefaultAsync(s => s.StoreId == id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            if (store == null)
            {
                return BadRequest("Store object is null.");
            }

            // Ensure CustomerLocations is initialized if required
            if (store.CustomerLocations == null)
            {
                store.CustomerLocations = new List<StoreCustomerLocation>();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
        }



        // PUT: api/Stores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Stores.Any(e => e.StoreId == id))
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

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
