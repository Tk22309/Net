using Microsoft.AspNetCore.Mvc;
using Drink.Infrastructure.Models;
using Drink.Infrastructure.Service;
using System.Net;

namespace Drink.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ICrudServiceAsync<DrinkModel> _service;

        public DrinkController(ICrudServiceAsync<DrinkModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrinkModel>>> GetAll()
        {
            var drinks = await _service.ReadAllAsync();
            return Ok(drinks);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DrinkModel>> GetById(Guid id)
        {
            var drink = await _service.ReadAsync(id);
            if (drink == null)
                return NotFound();
            return Ok(drink);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DrinkModel model)
        {
            var result = await _service.CreateAsync(model);
            if (!result) return BadRequest();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] DrinkModel model)
        {
            var result = await _service.UpdateAsync(model);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var drink = await _service.ReadAsync(id);
            if (drink == null) return NotFound();

            var result = await _service.RemoveAsync(drink);
            if (!result) return BadRequest();

            return NoContent();
        }
    }
}
