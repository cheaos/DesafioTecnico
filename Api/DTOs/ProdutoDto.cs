namespace Api.DTOs;

public class ProdutoDto{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public double Valor { get; set; }
    public int QuantidadeEstoque { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
