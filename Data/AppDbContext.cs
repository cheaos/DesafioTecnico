using ControleProdutoEstoque.Modelos;
using Microsoft.EntityFrameworkCore;

/* É a classe que vai gerenciar no projeto todo o banco de dados e as duas tabelas que constam nele, de Produtos e MovimentacoesEstoque. */

namespace ControleProdutoEstoque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }


    }
}

