using MottuGestor.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MottuGestor.Infrastructure.Persistence.Repositories;

namespace MottuGestor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotosController : ControllerBase
    {
        private readonly IMotoRepository _repository;

        public MotosController(IMotoRepository repository)
        {
            _repository = repository;
        }
        /// Lista todas as motos cadastradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> GetAll()
        {
            var motos = await _repository.GetAllAsync();
            return Ok(motos);
        }

        /// Busca uma moto pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> GetById(int id)
        {
            var moto = await _repository.GetByIdAsync(id);
            if (moto is null) return NotFound();
            return Ok(moto);
        }

        /// Busca motos pelo modelo (via query param)
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Moto>>> GetByModelo([FromQuery] string modelo)
        {
            var motos = await _repository.GetByModeloAsync(modelo);
            return Ok(motos);
        }

        /// Cadastra uma nova moto
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Moto moto)
        {
            if (moto == null) return BadRequest();
            await _repository.AddAsync(moto);
            return CreatedAtAction(nameof(GetById), new { id = moto.Id }, moto);
        }

        /// Atualiza os dados de uma moto
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Moto moto)
        {
            if (id != moto.Id) return BadRequest("ID da URL diferente do corpo");
            await _repository.UpdateAsync(moto);
            return NoContent();
        }

        /// Remove uma moto pelo ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existente = await _repository.GetByIdAsync(id);
            if (existente is null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
