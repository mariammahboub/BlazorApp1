using Core.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null.");
            }

            try
            {
                await _repository.AddAsync(entity);
                return CreatedAtAction(nameof(Create), new { id = entity.GetType().GetProperty("Id")?.GetValue(entity, null) }, entity);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _repository.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null.");
            }

            try
            {
                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }

                // Update entity logic (make sure to set the ID properly)
                await _repository.UpdateAsync(entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
