using Api.Models;
using Api.DTOs;
using Api.Controllers;
using Api.Repositories;

namespace Api.Services;

public class ProdutoService{
    private readonly ProdutoRepository _prodRepo;
    private readonly MovimentacaoRepository _movRepo;

    public ProdutoService(ProdutoRepository prodRepo, MovimentacaoRepository movRepo){
        _prodRepo = prodRepo;
        _movRepo = movRepo;
    }

    public async Task<ProdutoDto> CriarProdutoAsync(CreateProdutoDto dto){
        var produto = new Produto{
            Nome = dto.Nome,
            Tipo = dto.Categoria,
            Valor = dto.Preco,
            QuantidadeEstoque = 0
        };

        await _prodRepo.AdicionarAsync(produto);

        var movimentacaoCriacao = new Movimentacao{
            ProdutoId = produto.Id,
            Quantidade = dto.Quantidade,
            ValorUnitario = dto.Preco,
            Tipo = "Criacao",
            Data = DateTime.UtcNow
        };

        await _movRepo.AdicionarAsync(movimentacaoCriacao);

        produto.QuantidadeEstoque = dto.Quantidade;
        await _prodRepo.AtualizarAsync(produto);

        return new ProdutoDto{
            Id = produto.Id,
            Nome = produto.Nome,
            Tipo = produto.Tipo,
            Valor = produto.Valor,
            QuantidadeEstoque = produto.QuantidadeEstoque,
            CriadoEm = produto.CriadoEm
        };
    }

    public async Task<IEnumerable<ProdutoDto>> ListarTodosAsync() {
        var produtos = await _prodRepo.BuscarTodosAsync();
        return produtos.Select(p => new ProdutoDto {
            Id = p.Id,
            Nome = p.Nome,
            Tipo = p.Tipo,
            Valor = Math.Round(p.Valor, 2),
            QuantidadeEstoque = p.QuantidadeEstoque,
            CriadoEm = p.CriadoEm
        });
    }

    public async Task<ProdutoDto?> ObterPorIdAsync(int id) {
        var produto = await _prodRepo.BuscarPorIdAsync(id);
        if (produto == null) return null;

        return new ProdutoDto {
            Id = produto.Id,
            Nome = produto.Nome,
            Tipo = produto.Tipo,
            Valor = produto.Valor,
            QuantidadeEstoque = produto.QuantidadeEstoque,
            CriadoEm = produto.CriadoEm
        };
    }

    public async Task<bool> RemoverProdutoAsync(int id) {
        var produto = await _prodRepo.BuscarPorIdAsync(id);
        if (produto == null) return false;

        var movimentacaoExclusao = new Movimentacao{
            ProdutoId = produto.Id,
            Quantidade = 0,
            ValorUnitario = 0,
            Tipo = "Exclusao",
            Data = DateTime.UtcNow
        };

        await _movRepo.AdicionarAsync(movimentacaoExclusao);

        await _prodRepo.RemoverAsync(produto);
        return true;
    }

}
