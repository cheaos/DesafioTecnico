using System.Security.Cryptography.X509Certificates;

namespace ControleProdutoEstoque.Modelos
{
    /* CLASSE que vai definir todas as INFOS que a MOVIMENTAÇÃO vai ter. */
    /* O TipoMovimentacao é um "ENUM" pois vamos conseguir REFERENCIAR com 0, 1, 2 para cada tipo. */
    public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }

    public class MovimentacaoEstoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public decimal? ValorVenda { get; set; }
    }
}
