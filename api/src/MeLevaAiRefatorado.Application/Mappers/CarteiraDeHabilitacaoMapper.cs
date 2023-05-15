using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
