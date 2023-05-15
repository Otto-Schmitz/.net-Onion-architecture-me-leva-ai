using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida
{
    public class IniciarCorridaDto : Notifiable
    {
        public double TempoEstimadoDestino { get; set; }

        public double ValorEstimado { get; set; }
    }
}

