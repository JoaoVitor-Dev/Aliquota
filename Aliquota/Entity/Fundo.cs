namespace Aliquota.Entity
{
    public class Fundo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aplicacao> Aplicacoes { get; set; }
        public List<Resgate> Resgates { get; set; }

        public Fundo(string nome)
        {
            Nome = nome;
        }
        private Fundo()
        {
            
        }

        public Aplicacao ObterAplicacao(int aplicacaoId)
        {
            var aplicacao = Aplicacoes.Find(x => x.Id == aplicacaoId);

            if (aplicacao == null)
                throw new ArgumentException("Aplicação não encontrada.");

            return aplicacao;
        }
    }
}
