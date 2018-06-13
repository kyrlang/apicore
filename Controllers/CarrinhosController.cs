using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aula02.Models;
using Newtonsoft.Json.Linq;

namespace Aula02.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarrinhosController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CarrinhoModel>> Carrinho(string id)
        {
            List<LivroModel> livro = new List<LivroModel>();
            livro.Add(new LivroModel("Livro Um", "Autor Um", 1986, "LV01A"));
            livro.Add(new LivroModel("Livro Dois", "Autor Dois", 1996, "LV02A"));
            CarrinhoModel carrinho = new CarrinhoModel();
            carrinho.IdCarrinho = id;
            carrinho.Livro = livro;
            return Ok(carrinho);
        }


        // GET api/values
        [HttpPost]
        public ActionResult<IEnumerable<CarrinhoModel>> Carrinho([FromBody] JObject livro)
        {
            try
            {
                CarrinhoModel carrinho = new CarrinhoModel();
                carrinho.IdCarrinho = "01";
                carrinho.Livro = livro.ToObject<List<LivroModel>>();
                return Created("", carrinho);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("encerrado")]
        public ActionResult<IEnumerable<CarrinhoModel>> FinalizarPedido(CarrinhoModel carrinho)
        {
            return Ok("ok");
        }        

        // GET api/values/5
        [HttpDelete("livro/{isbn}")]
        public ActionResult<string> LivroId(string isbn)
        {
            return Ok("Livro retirado do carrinho");
        }

        [HttpPost("status")]
        public ActionResult<string> Status(string idStatus, int idCarrinho)
        {
            return Ok("Status do carrinho: " + idCarrinho + " alterado para: " + idStatus);
        }        

        [HttpGet("status/{idCarrinho}")]
        public ActionResult<string> Status(int idCarrinho)
        {
            return Ok("Status do carrinho: " + idCarrinho + " é 1 ");
        }
    }
}
