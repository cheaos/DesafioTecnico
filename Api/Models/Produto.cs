namespace Api.Models;

public class Produto{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public float Valor { get; set; }
    public int QuantidadeEstoque { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    public void AdicionarEstoque(int quantidade, float novoValorFornecedor){
        if (quantidade < 1)
            throw new InvalidOperationException("Quantidade deve ser maior que zero.");
        
        if (novoValorFornecedor <= 0)
            throw new InvalidOperationException("Valor deve ser maior que zero.");

        QuantidadeEstoque += quantidade;
        Valor = novoValorFornecedor;
    }

    public void RemoverEstoque(int quantidade){
        if (quantidade > QuantidadeEstoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        if (quantidade < 1)
            throw new InvalidOperationException("Quantidade deve ser maior que zero.");

        QuantidadeEstoque -= quantidade;
    }

}