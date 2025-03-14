namespace Aliquota.Entity
{
    public class Aplicacao
    {
       public int Id { get; set; }
       public decimal Valor { get; set; }
       public DateTime DataAplicacao { get; set; }
       public int FundoId { get; set; }
       public int ClienteId { get; set; }
       public Fundo Fundo { get; set; }
       public Cliente Cliente { get; set; }

       private Aplicacao() { }

       public Aplicacao(decimal valor, DateTime dataAplicacao, int fundoId, int clienteId)
       {
            if (valor <= 0)
                throw new ArgumentException("O valor da aplicação deve ser maior que zero.");

            Valor = valor;
            DataAplicacao = dataAplicacao;
            FundoId = fundoId;
            ClienteId = clienteId;
       }

       public void RetirarSaldo(decimal valor)
       {
            Valor = valor - Valor;
       }
    }
}
