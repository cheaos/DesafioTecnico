using ControleDeEstoque.Models.DTOs;
using ControleDeEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;

    public EstoqueController(IEstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }

    [HttpPost("entrada")]
    public async Task<IActionResult> EntradaEstoque([FromBody] EntradaEstq dto)
    {
        var result = await _estoqueService.RealizarEntradaAsync(dto);
        return Ok(result);
    }

    [HttpPost("saida")]
    public async Task<IActionResult> SaidaEstoque([FromBody] SaidaEstq dto)
    {
        try
        {
            var result = await _estoqueService.RealizarSaidaAsync(dto);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpGet("historico")]
    public async Task<IActionResult> ObterHistorico()
    {
        var historico = await _estoqueService.ObterHistoricoAsync();
        return Ok(historico);
    }
}