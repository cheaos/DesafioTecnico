using ControleDeEstoque.Models.DTOs;
using ControleDeEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO dto)
    {
        var result = await _produtoService.CriarProdutoAsync(dto);
        return CreatedAtAction(nameof(ObterPorId), new { id = result.Id }, result);
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var produtos = await _produtoService.ObterTodosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterPorId(int id)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }
}