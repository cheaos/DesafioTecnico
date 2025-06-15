using Api.Models;
using Api.DTOs;

public class ProdutoService{
    private readonly ProdutoRepository _produtoRepo;

    public ProdutoService(ProdutoRepository produtoRepo){
        _produtoRepo = produtoRepo;
    }

    public async Task<ProdutoDto> CriarProdutoAsync(CreateProdutoDto dto){
        var produto = new Produto{
            Nome = dto.Nome,
            Tipo = dto.Categoria,
            Valor = dto.Preco
        };

        produto.AdicionarEstoque(dto.Quantidade, dto.Preco);

        await _produtoRepo.AddAsync(produto);

        return new ProdutoDto{
            Id = produto.Id,
            Nome = produto.Nome,
            Tipo = produto.Tipo,
            Valor = produto.Valor,
            QuantidadeEstoque = produto.QuantidadeEstoque,
            CriadoEm = produto.CriadoEm
        };
    }
}
