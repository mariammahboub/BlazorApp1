using Core.Contract;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantsController : ControllerBase
    {
        private readonly IGenericRepository<Merchant> _repository;

        public MerchantsController(IGenericRepository<Merchant> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Merchant merchant)
        {
            if (merchant == null)
            {
                return BadRequest("Merchant is null.");
            }

            if (string.IsNullOrWhiteSpace(merchant.Name))
            {
                return BadRequest("Merchant name is required.");
            }

            try
            {
                await _repository.AddAsync(merchant);
                return CreatedAtAction(nameof(Create), new { id = merchant.MerchantId }, merchant);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merchant>>> GetAll()
        {
            var merchants = await _repository.GetAllAsync();
            return Ok(merchants);
        }
    
}
    }

