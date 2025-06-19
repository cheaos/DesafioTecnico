using ControleDeEstoque.Models.DTOs;

namespace ControleDeEstoque.Services;

public interface IProdutoService
{
    Task<ProdutoDTO> CriarProdutoAsync(ProdutoDTO dto);
    Task<IEnumerable<ProdutoDTO>> ObterTodosAsync();
    Task<ProdutoDTO> ObterPorIdAsync(int id);
}