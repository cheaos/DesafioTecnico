using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController : ControllerBase
{
    private readonly MovimentacaoService _service;

    public MovimentacaoController(MovimentacaoService service){
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateMovimentacaoDto dto){
        try{
            await _service.Registrar(dto);
            return Ok("Movimentação registrada com sucesso");
        } catch (Exception ex){
            if (ex.Message.Contains("Produto não encontrado"))
                return NotFound(new { error = ex.Message });

            if (ex.Message.Contains("Estoque insuficiente"))
                return BadRequest(new { error = ex.Message });

            return StatusCode(500, new { error = "Erro interno: " + ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get(){
        var historico = await _service.ObterHistorico();
        return Ok(historico);
    }
}