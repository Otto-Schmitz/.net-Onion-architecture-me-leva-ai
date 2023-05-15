using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Models.Enuns;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo
{
    public class VeiculoDto : Notifiable
    {
        public Guid Id { get; set; }

        public Guid? MotoristaId { get; set; }

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string FotoUrl { get; set; }
    }
}