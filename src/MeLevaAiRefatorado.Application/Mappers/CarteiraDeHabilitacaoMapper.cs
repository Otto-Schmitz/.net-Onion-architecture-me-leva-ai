using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Application.Mappers
{
    public static class CarteiraDeHabilitacaoMapper
    {
        public static CarteiraDeHabilitacaoDto ToCarteiraDeHabilitacaoDto(this CarteiraDeHabilitacao carteiraDeHabilitacao)
            => new()
            {
                Numero = carteiraDeHabilitacao.Numero,
                Categoria = carteiraDeHabilitacao.Categoria,
                DataVencimento = carteiraDeHabilitacao.DataVencimento
            };
    }
}
