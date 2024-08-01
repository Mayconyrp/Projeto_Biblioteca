using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ProjetoBiblioteca.Context;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LivrosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            try
            {
                var livros = _context.Livros.ToList();
                if (livros is null)
                {
                    return NotFound("Livro não encontrado...");
                }
                return livros;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao tratar sua solicitação.");
            }
        }
        [HttpGet("{id:int}", Name = "ObterLivro")]
        public ActionResult<Livro> Get(int id)
        {
            try
            {
                var livros = _context.Livros.FirstOrDefault(l => l.LivroId == id);
                if (livros is null)
                {
                    return NotFound();
                }
                return livros;


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Ocorreu um erro ao tratar sua solicitação. ID procurado: {id}");
            }
        }

        [HttpPost]
        public ActionResult Post(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterLivro",
                new { id = livro.LivroId }, livro);

        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Livro livro)
        {
            if (id != livro.LivroId)
            {
                return BadRequest();
            }
            _context.Entry(livro).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(livro);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id, Livro livro)
        {
            var livros = _context.Livros.FirstOrDefault(l => l.LivroId == id);
            if (livro is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return Ok(livro);
        }

    }
}
