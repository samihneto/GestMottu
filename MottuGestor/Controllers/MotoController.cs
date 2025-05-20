using _2TDSPG.API.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace _2TDSPG.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MotoController : ControllerBase
{
    private static List<Moto> _motos = new(); // Simulando um "banco" em memória

    // GET: /Moto
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_motos);
    }

    // GET: /Moto/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var moto = _motos.FirstOrDefault(m => m.MotoId == id);
        if (moto == null)
            return NotFound("Moto não encontrada.");

        return Ok(moto);
    }

    // POST: /Moto
    [HttpPost]
    public IActionResult Create([FromBody] Moto motoInput)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Criar nova moto
        Moto moto = new Moto(motoInput.RfidTag)
        {
            MotoId = Guid.NewGuid(),
            Placa = motoInput.Placa,
            Modelo = motoInput.Modelo,
            Marca = motoInput.Marca,
            Ano = motoInput.Ano,
            Problema = motoInput.Problema,
            Localizacao = motoInput.Localizacao,
            Status = motoInput.Status
        };

        _motos.Add(moto);

        return CreatedAtAction(nameof(GetById), new { id = moto.MotoId }, moto);
    }
}
