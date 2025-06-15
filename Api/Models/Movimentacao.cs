namespace Api.Models;

public class Movimentacao{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; } = null!;
    public DateTime Data { get; set; } = DateTime.UtcNow;
    public int Quantidade { get; set; }
    public float ValorUnitario { get; set; }
    public string Tipo { get; set; } = null!;
}
