using MeLevaAiRefatorado.Domain.Models.Enuns;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista.Dtos
{
    public class CarteiraDeHabilitacaoDto
    {
        public string Numero { get; set; }

        public Categoria Categoria { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
