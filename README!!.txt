************** READ ME **************

O projeto está separado em dois arquivos, backend e frontend.
Antes de executar, criar o seguinte banco de dados MySql:

CREATE TABLE Produtos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL,
    Descricao VARCHAR(100) NOT NULL,
    Tipo INT NOT NULL, -- 0: Eletronico, 1: Eletrodomestico, 2: Movel
    ValorFornecedor DECIMAL(18,2) NOT NULL,
    Quantidade INT NOT NULL
);


CREATE TABLE Movimentacoes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ProdutoId INT NOT NULL,
    Tipo INT NOT NULL, -- 0: Entrada, 1: Saída
    Quantidade INT NOT NULL,
    Valor DECIMAL(18,2) NOT NULL,
    Data DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT FK_Movimentacoes_Produtos FOREIGN KEY (produto)
        REFERENCES Produtos(Id)
        ON DELETE CASCADE
);

