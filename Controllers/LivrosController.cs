using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aula02.Models;
using System.Net.Http;
using Aula02.Classes;

namespace Aula02.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<LivroModel>> ListarLivros()
        {
            IList<LivroModel> livro = new List<LivroModel>();
            livro.Add(new LivroModel("Livro Um", "Autor Um", 1986, "LV01A"));
            livro.Add(new LivroModel("Livro Dois", "Autor Dois", 1996, "LV02A"));
            livro.Add(new LivroModel("Livro Tres", "Autor Tres", 1986, "LV03A"));
            livro.Add(new LivroModel("Livro Quatro", "Autor Quatro", 1986, "LV04A"));
            return Ok(livro);
        }

        // GET api/values/5
        [HttpGet("{isbn}")]
        public ActionResult<string> LivroId(string isbn)
        {
            LivroModel livro = new LivroModel("Livro Um", "Autor Um", 1986, isbn);
            return Ok(livro);
        }

        [HttpGet("filtro")]
        public ActionResult<string> Livro(string isbn, string titulo, string autor, int anopublicacao)
        {
            LivroModel livro = new LivroModel(titulo, autor, anopublicacao, isbn);
            return Ok(livro);
        }

        [HttpGet("{isbn}/comentarios")]
        public ActionResult<string> Comentarios(string isbn)
        {
            IList<ComentarioModel> livro = new List<ComentarioModel>();
            livro.Add(new ComentarioModel("Comentario Um", isbn));
            livro.Add(new ComentarioModel("Comentario Dois", isbn));
            return Ok(livro);
        }
       
    }
}
