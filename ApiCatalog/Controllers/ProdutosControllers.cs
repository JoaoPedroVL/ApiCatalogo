using ApiCatalog.Context;
using ApiCatalog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


        [HttpGet]
        public ActionResult<IEnumerable<Produtos>> Get()
        {
            var prodtutos = _context.Produtos.ToList();
            if (prodtutos is null)
            {
                return NotFound("Produtos nao encontrado");
            }
            return prodtutos;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produtos> Get(int id)
        {
            var produtos = _context.Produtos.FirstOrDefault(p=> p.Id == id);
            if (produtos == null)
            {
                return NotFound();
            }
            return produtos;
        }
    }
}
