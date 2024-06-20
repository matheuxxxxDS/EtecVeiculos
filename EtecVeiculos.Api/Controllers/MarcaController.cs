using EtecVeiculos.Api.Data;
using EtecVeiculos.Api.DTOs;
using EtecVeiculos.Api.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtecVeiculos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarcaController : ControllerBase
{
    private readonly AppDbContext _context;

    public MarcaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Marca>>> Get()
    {
        var tipos = await _context.Marcas.ToListAsync();
        return Ok(tipos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marca>> Get(int id)
    {
        var tipo = await _context.Marcas.FindAsync(id);
        if (tipo == null)
            return NotFound("Marca do Veículo não encontrado!");
        return Ok(tipo);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Create(MarcaDto MarcaDto)
    {
        if (ModelState.IsValid)
        {
           Marca Marca = new()
            {
                Nome = MarcaDto.Nome
            };
            await _context.AddAsync(MarcaDto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Marca.Id });
        }
        return BadRequest("Verifique os dados informados");
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Edit(int id, Marca Marca)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (!_context.Marcas.Any(q => q.Id == id))
                    return NotFound("Marca do Veículo não encontrado");

                if (id != Marca.Id)
                    return BadRequest("Verifique os dados informados");

                _context.Entry(Marca).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um problema: {ex.Message}");
            }
        }
        return BadRequest("Verifique os dados informados");
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var Marca = await _context.Marcas
                .FirstOrDefaultAsync(q => q.Id == id);
            if (Marca == null)
                return NotFound("Tipo de Veículo não encontrado");

            _context.Remove(Marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {

            return BadRequest($"Ocorreu um problema: {ex.Message}");
        }
    }
}
