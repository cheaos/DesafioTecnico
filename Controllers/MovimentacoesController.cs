using ControleProdutoEstoque.Data;
using ControleProdutoEstoque.Modelos;
using ControleProdutoEstoque.Modelos.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutoEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        /* recebe conexão banco de dados como parametro e atribui a uma variavel _context */
        public MovimentacoesController(AppDbContext context)
        {
            _context = context;
        }

        /* POST: api/movimentacoes/entrada */
        /* atualiza as infos no banco de dados com base no ID, como "entrada" */
        [HttpPost("entrada")]
        public async Task<IActionResult> RegistrarEntrada([FromBody] EntradaProdutoDto entradaDto)
        {
            var produto = await _context.Produtos.FindAsync(entradaDto.ProdutoId);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }

            produto.QuantidadeEstoque += entradaDto.Quantidade;
            produto.ValorFornecedor += entradaDto.NovoValorFornecido;

            var novaMovimentacao = new MovimentacaoEstoque
            {
                ProdutoId = entradaDto.ProdutoId,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = entradaDto.Quantidade,
                DataMovimentacao = DateTime.UtcNow
            };

            _context.MovimentacoesEstoque.Add(novaMovimentacao);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /* POST: api/movimentacoes/saida */
        /* retira (saida) as informações do banco de dados com base no ID */
        /* validando se encontra o produto (com base no ID) e verificando se tem Saldo disponível */
        /* também a "saida" subtrai a quantidade, pois está retirando do estoque */
        [HttpPost("saida")]
        public async Task<IActionResult> RegistrarSaida([FromBody] SaidaProdutoDto saidaDto)
        {
            var produto = await _context.Produtos.FindAsync(saidaDto.ProdutoId);

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }

            if (produto.QuantidadeEstoque < saidaDto.Quantidade)
            {
                return BadRequest("Saldo de estoque insuficiente para esta saida.");
            }

            produto.QuantidadeEstoque -= saidaDto.Quantidade;

            var NovaMovimentacao = new MovimentacaoEstoque
            {
                ProdutoId = saidaDto.ProdutoId,
                Tipo = TipoMovimentacao.Saida,
                Quantidade = saidaDto.Quantidade,
                DataMovimentacao = DateTime.UtcNow,
                ValorVenda = saidaDto.ValorVenda
            };

            _context.MovimentacoesEstoque.Add(NovaMovimentacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /* GET: api/movimentacoes/historico */
        /* dá um "Get" pra pegar o histórico de movimentações */
        /* não estamos utilizando no frontend esta visão, mas colocamos no intuito de utilizar porém não tive tempo :( */
        [HttpGet("historico")]
        public async Task<ActionResult<IEnumerable<MovimentacaoEstoque>>> GetHistorico()
        {
            var historico = await _context.MovimentacoesEstoque.Include(m => m.Produto).OrderByDescending(m => m.DataMovimentacao).ToListAsync();

            return Ok(historico);
        }
    }
}
