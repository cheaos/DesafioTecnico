using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleProdutoEstoque.Data;
using ControleProdutoEstoque.Modelos;

namespace ControleProdutoEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        /* recebe a conexão do banco como parâmetro */
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        /* GET: api/ProdutosControlador */
        /* busca todos os produtos cadastrados no banco, trazendo em forma de list */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        /* GET: api/ProdutosControlador/5 */
        /* busca todos os produtos com base no ID, e uma cond. IF para caso produto for null, ele retorna "NotFound" (não encontrado) */
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        /* usa um PUT para modificar o produto com base no ID */
        [HttpPut("id/{id}")]
        public async Task<IActionResult> PutProdutoPorId(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /* POST: api/ProdutosControlador */
        /* usa um POST para adicionar um produto novo */
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        /* DELETE: api/ProdutosControlador/5 */
        /* deletar o produto com base no ID */
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
            
        /* basicamente verifica se o ID existe no banco, e returna como uma variável lógica true ou false, usando o _context ou seja faz uma consulta no banco de dadosss */
            private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
