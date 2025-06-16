namespace ControleProdutoEstoque.Modelos
{ 

    /* Classe que vai definir todas as infos que o produto vai ter. */
    /* O TipoProduto é um "enum" pois vamos conseguir referenciar com 0, 1, 2 para cada tipo. */

    public enum TipoProduto
    {
    Eletronico,
    Eletrodomestico,
    Movel
    }
    public class Produto
    {
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public TipoProduto Tipo { get; set; }
    public decimal ValorFornecedor { get; set; }
    public int QuantidadeEstoque { get; set; }
    }

}
