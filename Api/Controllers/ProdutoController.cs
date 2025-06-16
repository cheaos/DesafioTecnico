using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Models;
using Api.Data;
using Api.Services;

namespace Api.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service){
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var produtos = await _service.ListarTodosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id){
        var produto = await _service.ObterPorIdAsync(id);
        if (produto == null) 
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProdutoDto dto){
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var produto = await _service.CriarProdutoAsync(dto);
        return CreatedAtAction(nameof(GetOne), new { id = produto.Id }, produto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id){
        var sucesso = await _service.RemoverProdutoAsync(id);
        if (!sucesso) 
            return NotFound();
        return NoContent();
    }
}
