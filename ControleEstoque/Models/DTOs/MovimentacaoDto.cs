namespace ControleEstoque.Models.DTOs
{
    public class MovimentacaoDto
    {
        public string ProdutoDescricao { get; set; }
        public string TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public decimal? ValorVenda { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
