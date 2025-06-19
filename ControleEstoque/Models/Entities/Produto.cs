namespace ControleEstoque.Models.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string TipoProduto { get; set; } 
        public decimal ValorFornecedor { get; set; }
        public int QuantidadeEstoque { get; set; }
        public ICollection<MovimentacaoEstoque> Movimentacoes { get; set; } = new List<MovimentacaoEstoque>();
    }
}
