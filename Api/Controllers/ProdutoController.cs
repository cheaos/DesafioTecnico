using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Models;
using Api.Data;

namespace Api.Controllers;

[Controller]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context){
        _context = context;
    }

    [HttpGet]
    public IActionResult Get() =>
        Ok(_context.Produtos.Select(p => new ProdutoDto{
            Id = p.Id,
            Nome = p.Nome,
            Tipo = p.Tipo,
            Valor = p.Valor,
            QuantidadeEstoque = p.QuantidadeEstoque,
            CriadoEm = p.CriadoEm
        }));


    [HttpPost]
    public IActionResult Post([FromBody] CreateProdutoDto dto){
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var produto = new Produto{
            Nome = dto.Nome,
            Tipo = dto.Categoria,
            Valor = dto.Preco,
            QuantidadeEstoque = dto.Quantidade
        };

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var produto = _context.Produtos.Find(id);
        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return NoContent();
    }
}
