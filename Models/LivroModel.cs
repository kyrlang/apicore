using System;

namespace Aula02.Models
{
    public class LivroModel
    {
        public string Titulo {get; set;}
        public string Autor {get; set;}
        public int AnoPublicacao {get; set;}
        public string ISBN {get; set;}
        public string Comentario {get; set;}
        public LivroModel(){}
        public LivroModel(string titulo, string autor, int anoPublicacao, string isbn ) {
            this.Titulo = titulo;
            this.Autor = autor;
            this.AnoPublicacao = anoPublicacao;
            this.ISBN = isbn;
        }

    }
}