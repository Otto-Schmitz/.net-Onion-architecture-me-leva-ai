using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Application.Validations.Core;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida
{
    public class CorridaDto : Notifiable
    {
        public Guid Id { get; set; }

        public string NomePassageiro { get; set; }

        public string NomeMotorista { get; set; }

        public VeiculoDto Veiculo { get; set; }

        public int TempoEstimando { get; set; }

        public CoordenadasDto Pontos { get; set; }
    }
}
