using System;
using System.Collections.Generic;

namespace Aula02.Models
{
    public class CarrinhoModel
    {
        public string IdCarrinho {get; set;}
        public List<LivroModel> Livro {get; set;}

        public Usuario Usuario {get;set;}
    }
}