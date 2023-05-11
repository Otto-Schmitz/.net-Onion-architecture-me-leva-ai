using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro
{
    public class AvaliarPassageiroDto : Notifiable
    {
        public Guid CorridaId { get; set; }

        public string NomePassageiro { get; set; }

        public int Nota { get; set; }

        public string Descricao { get; set; }

    }
}
