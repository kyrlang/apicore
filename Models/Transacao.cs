namespace Aula02.Models
{
    public class Transacao
    {
        public string IdPedido { get; set; } 
        public double Valor { get; set; }
        public string NumCartao { get; set; }
        public string Validade { get; set; }
        public string Nome { get; set; }
        public string CdSeguranca { get; set; }
        public Usuario Usuario { get; set; }
    }     
}