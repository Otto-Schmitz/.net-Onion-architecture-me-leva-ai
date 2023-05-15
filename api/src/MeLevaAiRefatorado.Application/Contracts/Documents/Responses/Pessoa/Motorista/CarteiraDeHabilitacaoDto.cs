using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Models.Enuns;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista
{
    public class CarteiraDeHabilitacaoDto : Notifiable
    {
        public string Numero { get; set; }

        public Categoria Categoria { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
