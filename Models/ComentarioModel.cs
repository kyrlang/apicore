using System;

namespace Aula02.Models
{
    public class ComentarioModel
    {
        public string Comentario {get; set;}
        public string ISBN {get; set;}
        public ComentarioModel(string comentario, string isbn ) {
            this.Comentario = comentario;
            this.ISBN = isbn;
        }
    }
}