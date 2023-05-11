using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro
{
    public class PassageiroDto : Notifiable
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public double Saldo { get; set; }

        public List<AvaliacaoDto> Avaliacoes { get; set; }

        public bool EmCorrida { get; set; }
    }
}
