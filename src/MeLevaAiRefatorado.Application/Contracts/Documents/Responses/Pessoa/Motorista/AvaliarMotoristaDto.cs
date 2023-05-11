using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista
{
    public class AvaliarMotoristaDto : Notifiable
    {
        public Guid CorridaId { get; set; }

        public string NomeMotorista { get; set; }

        public int Nota { get; set; }

        public string Descricao { get; set; }

    }
}
