using Microsoft.AspNetCore.Mvc;
using Drink.Infrastructure.Models;
using Drink.Infrastructure.Service;
using System.Net;

namespace Drink.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspressoController : ControllerBase
    {
        private readonly ICrudServiceAsync<EspressoModel> _service;

        public EspressoController(ICrudServiceAsync<EspressoModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspressoModel>>> GetAll()
        {
            var list = await _service.ReadAllAsync();
            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EspressoModel>> GetById(Guid id)
        {
            var item = await _service.ReadAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EspressoModel model)
        {
            var created = await _service.CreateAsync(model);
            if (!created) return BadRequest();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] EspressoModel model)
        {
            var updated = await _service.UpdateAsync(model);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var item = await _service.ReadAsync(id);
            if (item == null) return NotFound();

            var deleted = await _service.RemoveAsync(item);
            if (!deleted) return BadRequest();

            return NoContent();
        }
    }
}
