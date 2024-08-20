using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCustomerLocationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StoreCustomerLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<StoreCustomerLocation>> PostStoreCustomerLocation(StoreCustomerLocation storeCustomerLocation)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine($"Model state errors: {string.Join(", ", errors)}"); // Debug output
                return BadRequest(ModelState);
            }

            try
            {
                _context.storeCustomerLocations.Add(storeCustomerLocation);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetStoreCustomerLocation", new { id = storeCustomerLocation.Id }, storeCustomerLocation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreCustomerLocation>> GetStoreCustomerLocation(int id)
        {
            var storeCustomerLocation = await _context.storeCustomerLocations.FindAsync(id);

            if (storeCustomerLocation == null)
            {
                return NotFound();
            }

            return storeCustomerLocation;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreCustomerLocation>>> GetStoreCustomerLocations()
        {
            return await _context.storeCustomerLocations.ToListAsync();
        }
    }
}
