namespace Api.Models;

public class Movimentacao{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public DateTime? Data { get; set; }
}
