namespace Aliquota.Entity
{
    public class Resgate
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public decimal ImpostoDeRenda { get; set; }
        public DateTime DataResgate { get; set; }
        public int FundoId { get; set; }
        public int ClienteId { get; set; }
        public Fundo Fundo { get; set; }
        public Cliente Cliente { get; set; }
        private Resgate() { }

        public Resgate(decimal valorResgate, DateTime dataResgate, Aplicacao aplicacao)
        {
            if (dataResgate < aplicacao.DataAplicacao)
                throw new ArgumentException("A data do resgate deve ser maior que a data da aplicação.");

          Valor = valorResgate;
          DataResgate = dataResgate;
          CalcularImpostoDeRenda(aplicacao);
        }

        private void CalcularImpostoDeRenda(Aplicacao aplicacao)
        {
            var lucro = Valor - aplicacao.Valor;
            var tempoAplicacao = (DataResgate - aplicacao.DataAplicacao).TotalDays / 365;

            if (tempoAplicacao <= 1)
                ImpostoDeRenda = lucro * 0.225m;
            else if (tempoAplicacao <= 2)
                ImpostoDeRenda = lucro * 0.185m;
            else 
                ImpostoDeRenda = lucro * 0.15m;

            Valor = Valor - ImpostoDeRenda;
        }
    }
}
