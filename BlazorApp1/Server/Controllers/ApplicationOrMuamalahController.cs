using Core.Contract;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;

namespace BlazorApp1.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationOrMuamalahController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<ApplicationOrMuamalah> _repository;

        public ApplicationOrMuamalahController(ApplicationDbContext context, IGenericRepository<ApplicationOrMuamalah> repository)
        {
            _context = context;
            _repository = repository;
        }


        [HttpPost]
        public async Task<ActionResult<ApplicationOrMuamalah>> PostStore([FromBody] ApplicationOrMuamalah store)
        {
            if (store == null)
            {
                return BadRequest("Store object is null.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(store);  // Corrected line
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = store.ApplicationId }, store);
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationOrMuamalah>>> GetAll()
        {
            try
            {
                var applications = await _repository.GetAllAsync();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "GetApplicationOrMuamalahById")]
        public async Task<ActionResult<ApplicationOrMuamalah>> GetById(int id)
        {
            try
            {
                var application = await _repository.GetByIdAsync(id);
                if (application == null)
                {
                    return NotFound();
                }
                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    

}
}
