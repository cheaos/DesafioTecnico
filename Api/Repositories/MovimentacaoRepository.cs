using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class MovimentacaoRepository{
    private readonly AppDbContext _context;

    public MovimentacaoRepository(AppDbContext context){
        _context = context;
    }

    public async Task<List<Movimentacao>> BuscarTodasAsync(){
        return await _context.Movimentacoes
            .Include(m => m.Produto)
            .OrderByDescending(m => m.Data)
            .ToListAsync();
    }

    public async Task<Movimentacao?> BuscarPorIdAsync(int id){
        return await _context.Movimentacoes
            .Include(m => m.Produto)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AdicionarAsync(Movimentacao movimentacao){
        _context.Movimentacoes.Add(movimentacao);
        await _context.SaveChangesAsync();
    }
}
