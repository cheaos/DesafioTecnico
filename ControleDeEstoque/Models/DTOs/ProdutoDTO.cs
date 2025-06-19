namespace ControleDeEstoque.Models.DTOs;

public class ProdutoDTO
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public string Tipo { get; set; } // Eletronico, Eletrodomestico, Movel
    public decimal ValorFornecedor { get; set; }
    public int Quantidade { get; set; }
}

