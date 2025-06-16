namespace ControleProdutoEstoque.Modelos.DTOs
{
    /* CLASSE que vai ser usada para definir os dados que a ENTRADA vai receber. */

    public class EntradaProdutoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal NovoValorFornecido { get; set; }

    }
}
