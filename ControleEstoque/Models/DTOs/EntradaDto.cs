namespace ControleEstoque.Models.DTOs
{
    public class EntradaDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorFornecedor { get; set; }
    }
}
