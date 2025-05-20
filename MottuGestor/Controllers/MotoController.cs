using MottuGestor.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MottuGestor.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MotoController : ControllerBase
{
    private static List<Moto> _motos = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_motos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var moto = _motos.FirstOrDefault(m => m.MotoId == id);
        if (moto == null)
            return NotFound("Moto não encontrada.");

        return Ok(moto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] MotoInputModel input)
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

            _motos.Add(moto);

            return CreatedAtAction(nameof(GetById), new { id = moto.MotoId }, moto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

// Modelo para entrada, separado da entidade
public class MotoInputModel
{
    public required string RfidTag { get; set; }
    public required string Placa { get; set; }
    public required string Modelo { get; set; }
    public required string Marca { get; set; }
    public required int Ano { get; set; }
    public required string Problema { get; set; }
    public required string Localizacao { get; set; }
}
