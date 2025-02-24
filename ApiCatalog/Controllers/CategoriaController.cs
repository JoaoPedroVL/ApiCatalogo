using ApiCatalog.Context;
using ApiCatalog.Filters;
using ApiCatalog.Model;
using ApiCatalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public CategoriaController(AppDbContext context, ILogger<CategoriaController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p=> p.Produtos).ToList();
        }



        [HttpGet("filter")]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            try
            {
                return await _context.Categorias.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                // tratamento de erro para cada end point 
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um problema ao tratar a sua solicitação");
            }
            
        }

        
        [HttpGet("FromServices/{nome}")]
        public ActionResult<string> GetSaudacoesFromServices([FromServices] IMeuServico meuSevico, string nome)
        {
            return meuSevico.Saudacao(nome);
        }

        [HttpGet("semFromServices/{nome}")]
        public ActionResult<string> GetSaudacoesSemFromServices( IMeuServico meuSevico, string nome)
        {
            return meuSevico.Saudacao(nome);
        }
        


        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> get(int id)
        {

            //throw new Exception("Exeção ao retornar a categoria pelo id");

            _logger.LogInformation($"#################################### GET Api/Categoria/id = {id} ###########");


            try
            {
                var categoria = _context.Categorias.SingleOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    _logger.LogInformation($"#################################### GET Api/Categoria/id = {id} NOT FUDN ###########");
                    return NotFound();
                }
                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um problema ao tratar a sua solicitação"); 
            }
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest($"Categoria com Id={id} nao encontrada");
            }
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }


        [HttpDelete("{id:int}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound($"produto com id={id} nao localizado");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }

}
    

