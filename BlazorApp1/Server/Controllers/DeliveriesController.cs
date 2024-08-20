using Core.Contract;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly IGenericRepository<Delivery> _repository;
                private readonly ApplicationDbContext _context;


        public DeliveriesController(IGenericRepository<Delivery> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;

        }
        [HttpPost]
        public async Task<ActionResult<Delivery>> CreateDelivery(Delivery Delivery)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Console.WriteLine($"Model state errors: {string.Join(", ", errors)}"); // Debug output
                return BadRequest(ModelState);
            }

            try
            {
                _context.Deliveries.Add(Delivery);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetById", new { id = Delivery.DeliveryId }, Delivery);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetAll()
        {
            return await _context.Deliveries.ToListAsync();
        }


        public async Task<ActionResult<Delivery>> GetById(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }



    }
}
