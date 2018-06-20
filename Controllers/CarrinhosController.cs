using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aula02.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Aula02.Classes;

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
        public ActionResult<IEnumerable<CarrinhoModel>> Carrinho([FromBody] CarrinhoModel carrinho)
        {
            try
            {
                
                carrinho.IdCarrinho = "01";
                carrinho.Livro = carrinho.Livro;

                if(login(carrinho.Usuario))
                    return Created("", carrinho);
                else
                    return BadRequest("Erro ao autenticar");
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("encerrado")]
        public ActionResult<IEnumerable<CarrinhoModel>> FinalizarPedido(CarrinhoModel carrinho)
        {
            Transacao transacao = new Transacao();
            HttpResponseMessage response;
            response = GlobalVariablesTrans.WebApiClient.PostAsJsonAsync("transacao/cartao", transacao).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                   return Ok("ok");
                else
                   return BadRequest();
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


        private bool login(Usuario usuario){
            try
            {
                HttpResponseMessage response;
                response = GlobalVariablesAuth.WebApiClient.PostAsJsonAsync("autenticacao/login", usuario).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        return true;
                    else
                        return false;    
            }
            catch(Exception ex){
                return false;
            }
        }        
    }
}
