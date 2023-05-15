using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa
{
    public class AvaliacaoDto : Notifiable
    {
        public Guid PessoaId { get; set; }

        public Guid CorridaId { get; set; }

        public int Nota { get; set; }

        public string Descricao { get; set; }
    }
}
