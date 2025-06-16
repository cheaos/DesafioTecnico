using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class ProdutoRepository{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context){
        _context = context;
    }

    public async Task<Produto?> BuscarPorIdAsync(int id) =>
        await _context.Produtos.FindAsync(id);

    public async Task<List<Produto>> BuscarTodosAsync() =>
        await _context.Produtos.ToListAsync();

    public async Task AdicionarAsync(Produto produto){
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Produto produto){
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

     public async Task RemoverAsync(Produto produto) {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
    }
}
