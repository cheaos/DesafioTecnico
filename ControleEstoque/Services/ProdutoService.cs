using ControleEstoque.Context;
using ControleEstoque.Models.DTOs;
using ControleEstoque.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ControleEstoque.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> ListarProdutosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task CadastrarProdutoAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task RealizarEntradaAsync(EntradaDto entrada)
        {
            var produto = await _context.Produtos.FindAsync(entrada.ProdutoId);
            produto.QuantidadeEstoque += entrada.Quantidade;
            produto.ValorFornecedor = entrada.ValorFornecedor;

            _context.Movimentacoes.Add(new MovimentacaoEstoque
            {
                ProdutoId = produto.Id,
                Quantidade = entrada.Quantidade,
                TipoMovimentacao = "Entrada",
                DataMovimentacao = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }

        public async Task RealizarSaidaAsync(SaidaDto saida)
        {
            var produto = await _context.Produtos.FindAsync(saida.ProdutoId);
            if (produto.QuantidadeEstoque < saida.Quantidade)
                throw new Exception("Saldo insuficiente em estoque");

            produto.QuantidadeEstoque -= saida.Quantidade;

            _context.Movimentacoes.Add(new MovimentacaoEstoque
            {
                ProdutoId = produto.Id,
                Quantidade = saida.Quantidade,
                ValorVenda = saida.ValorVenda,
                TipoMovimentacao = "Saida",
                DataMovimentacao = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }
        public async Task<List<MovimentacaoDto>> ObterHistoricoAsync()
        {
            return await _context.Movimentacoes
                .Include(m => m.Produto)
                .OrderByDescending(m => m.DataMovimentacao)
                .Select(m => new MovimentacaoDto
                {
                    ProdutoDescricao = m.Produto.Descricao,
                    TipoMovimentacao = m.TipoMovimentacao,
                    Quantidade = m.Quantidade,
                    ValorVenda = m.ValorVenda,
                    DataMovimentacao = m.DataMovimentacao
                })
                .ToListAsync();
        }
    }
}
