using Api.Models;

namespace Api.DTOs;

public class CreateMovimentacaoDto{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }
    public string Tipo { get; set; } = string.Empty;
}
