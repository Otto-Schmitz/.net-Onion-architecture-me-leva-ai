namespace MeLevaAiRefatorado.Domain.Models
{
    public class Motorista : Pessoa
    {
        public Guid CarteiraDeHabilitacaoId { get; set; }

        public List<Corrida> Corridas { get; init; } = new List<Corrida>();

        public bool EmCorrida { get; set; } = false;

        public Motorista(string nome, string email, DateTime dataNascimento, string cpf, Guid carteiraDeHabilitacaoId)
            : base(nome, email, dataNascimento, cpf)
        {
            CarteiraDeHabilitacaoId = carteiraDeHabilitacaoId;
        }

        public Motorista Alterar(Motorista motorista)
        {
            Nome = motorista.Nome;
            Email = motorista.Email;
            DataNascimento = motorista.DataNascimento;
            Cpf = motorista.Cpf;
            CarteiraDeHabilitacaoId = motorista.CarteiraDeHabilitacaoId;

            return this;
        }

        public override bool VerificaIdadeMinima()
        {
            int idadeMinima = 18;
            DateTime dataAtual = DateTime.Now;

            int idade = dataAtual.Year - DataNascimento.Year;
            if (DataNascimento > dataAtual.AddYears(-idade))
                --idade;

            return idade >= idadeMinima;
        }

        public void AdicionarCorrida(Corrida corrida)
        {
            Corridas.Add(corrida);
        }

        public void RemoverCorrida(Corrida corrida)
        {
            Corridas.Remove(corrida);
        }

        public Corrida? ObterCorrida(Guid id)
            => Corridas.FirstOrDefault(v => v.CorridaId == id);


        public void AlterarCorrida(Corrida corrida)
        {
            RemoverCorrida(ObterCorrida(corrida.CorridaId));
            AdicionarCorrida(corrida);
        }
    }
}
