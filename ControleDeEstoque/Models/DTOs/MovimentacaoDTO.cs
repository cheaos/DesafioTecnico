namespace ControleDeEstoque.Models.DTOs;

public class MovimentacaoDTO
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string ProdutoDescricao { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}