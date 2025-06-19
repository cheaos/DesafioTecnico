namespace ControleDeEstoque.Models.Entities;

public enum TipoMovimentacao { Entrada, Saida }

public class MovimentacaoEstoque
{
    public int Id { get; set; }
    public Produto Produto { get; set; }
    public int ProdutoId { get; set; }
    public TipoMovimentacao Tipo { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}