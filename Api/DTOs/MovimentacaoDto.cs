namespace Api.DTOs;

public class MovimentacaoDto {
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public double ValorUnitario { get; set; }
    public bool Tipo { get; set; }
    public DateTime? Data { get; set; }
}
