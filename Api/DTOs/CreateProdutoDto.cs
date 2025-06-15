using System.ComponentModel.DataAnnotations;

namespace Api.DTOs;

public class CreateProdutoDto{
    [Required]
    [StringLength(255)]
    public string Nome {get; set;} = string.Empty;

    [Range(0.01, double.MaxValue)]
    public float Preco {get; set;}

    [Required]
    [RegularExpression("Eletrônico|Eletrodoméstico|Móvel")]
    public string Categoria {get; set;} = string.Empty;

    [Range(0, int.MaxValue)]
    public int Quantidade {get; set;}
}