using ControleEstoque.Models.DTOs;
using ControleEstoque.Models.Entities;
using ControleEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutosController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ListarProdutosAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Produto produto)
    {
        await _service.CadastrarProdutoAsync(produto);
        return Ok();
    }

    [HttpPost("entrada")]
    public async Task<IActionResult> Entrada([FromBody] EntradaDto dto)
    {
        await _service.RealizarEntradaAsync(dto);
        return Ok();
    }

    [HttpPost("saida")]
    public async Task<IActionResult> Saida([FromBody] SaidaDto dto)
    {
        try
        {
            await _service.RealizarSaidaAsync(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    [HttpGet("historico")]
    public async Task<IActionResult> GetHistorico()
    {
        var movimentacoes = await _service.ObterHistoricoAsync();
        return Ok(movimentacoes);
    }

}