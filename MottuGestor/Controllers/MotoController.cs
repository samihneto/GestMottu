
using Microsoft.AspNetCore.Mvc;
using MottuGestor.API.Domain.Entities;
using MottuGestor.Infrastructure.Persistence.Repositories;
using MottuGestor.Models;

namespace MottuGestor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoController : ControllerBase
    {
        private readonly IRepository<Moto> _motoRepository;

        public MotoController(IRepository<Moto> motoRepository)
        {
            _motoRepository = motoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var motos = await _motoRepository.GetAllAsync();
            return Ok(motos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var moto = await _motoRepository.GetByIdAsync(id);
            if (moto == null)
                return NotFound("Moto não encontrada.");

            return Ok(moto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MotoInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var moto = new Moto(
                    rfidTag: input.RfidTag,
                    placa: input.Placa,
                    modelo: input.Modelo,
                    marca: input.Marca,
                    ano: input.Ano,
                    problema: input.Problema,
                    localizacao: input.Localizacao
                );

                await _motoRepository.AddAsync(moto);
                await _motoRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = moto.MotoId }, moto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
