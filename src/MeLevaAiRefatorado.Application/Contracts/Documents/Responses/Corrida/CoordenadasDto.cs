using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida
{
    public class CoordenadasDto : Notifiable
    {
        public Coordenadas PontoInicial { get; set; }

        public Coordenadas PontoFinal { get; set; }
    }
}
