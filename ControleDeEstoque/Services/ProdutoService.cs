using ControleDeEstoque.DBContext;
using ControleDeEstoque.Models.DTOs;
using ControleDeEstoque.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;

    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProdutoDTO> CriarProdutoAsync(ProdutoDTO dto)
    {
        var produto = new Produto
        {
            Codigo = dto.Codigo,
            Descricao = dto.Descricao,
            Tipo = Enum.Parse<TipoProduto>(dto.Tipo, true),
            ValorFornecedor = dto.ValorFornecedor,
            Quantidade = dto.Quantidade
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        dto.Id = produto.Id;
        return dto;
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterTodosAsync()
    {
        return await _context.Produtos
            .Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Descricao = p.Descricao,
                Tipo = p.Tipo.ToString(),
                ValorFornecedor = p.ValorFornecedor,
                Quantidade = p.Quantidade
            })
            .ToListAsync();
    }

    public async Task<ProdutoDTO> ObterPorIdAsync(int id)
    {
        var p = await _context.Produtos.FindAsync(id);
        if (p == null) return null;

        return new ProdutoDTO
        {
            Id = p.Id,
            Codigo = p.Codigo,
            Descricao = p.Descricao,
            Tipo = p.Tipo.ToString(),
            ValorFornecedor = p.ValorFornecedor,
            Quantidade = p.Quantidade
        };
    }
}