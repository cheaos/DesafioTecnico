using Api.DTOs;
using Api.Models;
using Api.Repositories;

namespace Api.Services;

public class MovimentacaoService{
    private readonly MovimentacaoRepository _movimentacaoRepo;
    private readonly ProdutoRepository _produtoRepo;
    private static readonly HashSet<string> TiposValidos = new() {
        "entrada", "saida", "criacao", "exclusao", "ajuste"
    };

    public MovimentacaoService(MovimentacaoRepository movimentacaoRepo, ProdutoRepository produtoRepo){
        _movimentacaoRepo = movimentacaoRepo;
        _produtoRepo = produtoRepo;
    }

    public async Task Registrar(CreateMovimentacaoDto dto){
        var tipo = dto.Tipo.ToLowerInvariant();
        if (!TiposValidos.Contains(tipo))
            throw new Exception("Tipo de movimentação inválido.");

        var produto = await _produtoRepo.BuscarPorIdAsync(dto.ProdutoId) 
            ?? throw new Exception("Produto não encontrado");

        switch (tipo){
            case "entrada":
            case "criacao":
            case "ajuste":
                if (dto.Quantidade < 0)
                    throw new Exception("Quantidade inválida para movimentação de entrada.");

                produto.QuantidadeEstoque += dto.Quantidade;
                produto.Valor = dto.ValorUnitario;
                break;

            case "saida":
                if (produto.QuantidadeEstoque < dto.Quantidade)
                    throw new Exception("Estoque insuficiente para saída.");

                produto.QuantidadeEstoque -= dto.Quantidade;
                produto.Valor = dto.ValorUnitario;
                break;

            case "exclusao":
            default:
                throw new Exception("Tipo de movimentação inválido.");
        }

        var movimentacao = new Movimentacao{
            ProdutoId = dto.ProdutoId,
            Quantidade = dto.Quantidade,
            ValorUnitario = dto.ValorUnitario,
            Tipo = dto.Tipo ,
        };

        await _movimentacaoRepo.AdicionarAsync(movimentacao);
        await _produtoRepo.AtualizarAsync(produto);
    }

    public async Task<List<Movimentacao>> ObterHistorico(){
        return await _movimentacaoRepo.BuscarTodasAsync();
    }
}
