using ControleDeEstoque.Models.DTOs;

namespace ControleDeEstoque.Services;

public interface IEstoqueService
{
    Task<MovimentacaoDTO> RealizarEntradaAsync(EntradaEstq dto);
    Task<MovimentacaoDTO> RealizarSaidaAsync(SaidaEstq dto);
    Task<IEnumerable<MovimentacaoDTO>> ObterHistoricoAsync();
}