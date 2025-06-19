using ControleDeEstoque.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.DBContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<MovimentacaoEstoque> Movimentacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>().HasKey(p => p.Id);
        modelBuilder.Entity<MovimentacaoEstoque>().HasKey(m => m.Id);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Codigo)
            .IsRequired();

        modelBuilder.Entity<MovimentacaoEstoque>()
            .Property(m => m.Tipo)
            .IsRequired();

        modelBuilder.Entity<MovimentacaoEstoque>()
            .HasOne(m => m.Produto)
            .WithMany(p => p.Movimentacoes)
            .HasForeignKey(m => m.ProdutoId);

        modelBuilder.Entity<Produto>()
            .HasMany(p => p.Movimentacoes)
            .WithOne(m => m.Produto)
            .HasForeignKey(m => m.ProdutoId);
    }
}



