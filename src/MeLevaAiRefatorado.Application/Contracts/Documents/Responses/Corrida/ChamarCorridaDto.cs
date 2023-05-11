using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida
{
    public class ChamarCorridaDto : Notifiable
    {
        public Guid CorridaID { get; set; }

        public VeiculoDto Veiculo { get; set; }

        public int TempoEstimado { get; set; }
    }
}