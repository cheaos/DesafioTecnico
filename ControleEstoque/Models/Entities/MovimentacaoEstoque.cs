namespace ControleEstoque.Models.Entities
{
    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorVenda { get; set; } 
        public string TipoMovimentacao { get; set; } 
    }
}
