using ControleDeEstoque.DBContext;
using ControleDeEstoque.Models.DTOs;
using ControleDeEstoque.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.Services;

public class EstoqueService : IEstoqueService
{
    private readonly AppDbContext _context;

    public EstoqueService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MovimentacaoDTO> RealizarEntradaAsync(EntradaEstq dto)
    {
        var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
        if (produto == null) throw new Exception("Produto não encontrado");

        produto.Quantidade += dto.Quantidade;
        produto.ValorFornecedor = dto.ValorFornecedor;

        var mov = new MovimentacaoEstoque
        {
            Tipo = TipoMovimentacao.Entrada,
            Quantidade = dto.Quantidade,
            Valor = dto.ValorFornecedor,
            Data = DateTime.Now,
            ProdutoId = produto.Id,
        };

        _context.Movimentacoes.Add(mov);
        await _context.SaveChangesAsync();

        return new MovimentacaoDTO
        {
            Id=mov.Id,
            Data=mov.Data,
            Quantidade=mov.Quantidade,
            ProdutoDescricao=produto.Descricao,
            Tipo= TipoMovimentacao.Entrada.ToString(),
            Valor=mov.Valor

        };
    }

    public async Task<MovimentacaoDTO> RealizarSaidaAsync(SaidaEstq dto)
    {
        var produto = await _context.Produtos.FindAsync(dto.ProdutoId);
        if (produto == null) throw new Exception("Produto não encontrado");

        if (dto.Quantidade > produto.Quantidade)
            throw new InvalidOperationException("Saldo insuficiente para saída.");

        produto.Quantidade -= dto.Quantidade;

        var mov = new MovimentacaoEstoque
        {
            Tipo = TipoMovimentacao.Saida,
            Quantidade = dto.Quantidade,
            Valor = dto.ValorVenda,
            Data = DateTime.Now,
            ProdutoId = produto.Id,
        };

        _context.Movimentacoes.Add(mov);
        await _context.SaveChangesAsync();

        return new MovimentacaoDTO
        {
            Id = mov.Id,
            Data = mov.Data,
            Quantidade = mov.Quantidade,
            ProdutoDescricao = produto.Descricao,
            Tipo = TipoMovimentacao.Entrada.ToString(),
            Valor = mov.Valor
        };
    }

    public async Task<IEnumerable<MovimentacaoDTO>> ObterHistoricoAsync()
    {
        return await _context.Movimentacoes
            .Include(m => m.Produto)
            .OrderByDescending(m => m.Data)
            .Select(m => new MovimentacaoDTO
            {
                Id = m.Id,
                Data = m.Data,
                ProdutoDescricao = m.Produto.Descricao,
                Quantidade = m.Quantidade,
                Tipo = m.Tipo.ToString(),
                Valor = m.Valor 
            })
            .ToListAsync();
    }
}