using Microsoft.AspNetCore.Mvc;
using MottuGestor.API.Domain.Entities;
using MottuGestor.API.Models;
using MottuGestor.Infrastructure.Persistence.Repositories;
using System.Net;

namespace MottuGestor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly IRepository<Patio> _patioRepository;

        public PatioController(IRepository<Patio> patioRepository)
        {
            _patioRepository = patioRepository;
        }

        // [GET] /patio
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patios = await _patioRepository.GetAllAsync();
            return Ok(patios);
        }

        // [GET] /patio/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var patio = await _patioRepository.GetByIdAsync(id);
            if (patio == null)
                return NotFound("Patio não encontrado.");

            return Ok(patio);
        }

        // [POST] /patio
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatioInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var patio = new Patio(
                    nome: input.Nome,
                    endereco: input.Endereco,
                    capacidade: input.Capacidade
                );

                await _patioRepository.AddAsync(patio);
                await _patioRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = patio.Id }, patio);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar pátio: {ex.Message}");
            }
        }

        // [PUT] /patio/{id}
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(Guid id, [FromBody] PatioInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patioExistente = await _patioRepository.GetByIdAsync(id);
            if (patioExistente == null)
                return NotFound("Pátio não encontrado.");

            try
            {
                patioExistente.AtualizarDados(
                    nome: input.Nome,
                    endereco: input.Endereco,
                    capacidade: input.Capacidade
                );

                await _patioRepository.UpdateAsync(patioExistente);
                await _patioRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar pátio: {ex.Message}");
            }
        }

        // [DELETE] /patio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var patio = await _patioRepository.GetByIdAsync(id);
            if (patio == null)
                return NotFound("Pátio não encontrado.");

            try
            {
                await _patioRepository.DeleteAsync(id);
                await _patioRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao excluir pátio: {ex.Message}");
            }
        }
    }
}
