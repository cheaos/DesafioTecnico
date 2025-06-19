namespace ControleDeEstoque.Models.Entities;

public enum TipoProduto { Eletronico, Eletrodomestico, Movel }

public class Produto
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public TipoProduto Tipo { get; set; }
    public decimal ValorFornecedor { get; set; }
    public int Quantidade { get; set; }
    public ICollection<MovimentacaoEstoque> Movimentacoes { get; set; } 
}