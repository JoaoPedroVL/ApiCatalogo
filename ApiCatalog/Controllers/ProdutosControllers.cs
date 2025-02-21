using ApiCatalog.Context;
using ApiCatalog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosControllers(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/asincro")]
        public async Task<ActionResult<IEnumerable<Produtos>>> Getasincro()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        [HttpGet("/verproduto")]
        public ActionResult<IEnumerable<Produtos>> Get()
        {
            var prodtutos = _context.Produtos.ToList();
            if (prodtutos is null)
            {
                return NotFound("Produtos nao encontrado");
            }
            return prodtutos;
        }

        [HttpGet("/verprodutoUnico{id:int}", Name= "ObeterProduto")]
        public async Task<ActionResult<Produtos>> Get(int id, [BindRequired]string nome)
        {
            var nomeProduto = nome;
            var produtos = await _context.Produtos.FirstOrDefaultAsync(p=> p.Id == id);

            if (produtos == null)
            {
                return NotFound();
            }
            return produtos;
        }
    
        [HttpPost("/criarproduto")]
        public ActionResult Post(Produtos produto)
        {
            if (produto is null)
            {
                return BadRequest();
            }
            
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObeterProduto", new { id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produtos produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto is null)
            {
                return NotFound("produto nao localizado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        
    }
}
