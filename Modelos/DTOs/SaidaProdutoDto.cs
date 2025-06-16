namespace ControleProdutoEstoque.Modelos.DTOs
{
    /* CLASSE que vai ser usada para definir os dados que a SAIDA vai receber. */

    public class SaidaProdutoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorVenda { get; set; }
    }
}
