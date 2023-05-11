using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida
{
    public class FinalizarCorridaDto : Notifiable
    {
        public Guid CorridaId { get; set; }

        public double Valor { get; set; }

    }
}
