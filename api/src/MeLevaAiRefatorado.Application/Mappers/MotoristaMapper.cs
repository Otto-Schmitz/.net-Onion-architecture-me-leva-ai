using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista.Dtos;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Application.Mappers
{
    public static class MotoristaMapper
    {
        public static Motorista ToMotorista(this AdicionarMotoristaRequest request, CarteiraDeHabilitacao carteira)
            => new(request.Nome, request.Email, request.DataNascimento, request.Cpf, carteira.Id);

        public static Motorista ToAlterarMotorista(this AlterarMotoristaRequest request)
            => new(request.Nome, request.Email, request.DataNascimento, request.Cpf, request.CarteiraDeHabilitacao.Id);

        public static CarteiraDeHabilitacao ToCarteiraDeHabilitacao(this AdicionarMotoristaRequest request)
            => new(request.Numero, request.Categoria, request.DataVencimento);

        public static MotoristaDto ToMotoristaDto(this Motorista motorista)
            => new()
            {
                Id = motorista.Id,
                Nome = motorista.Nome,
                Email = motorista.Email,
                DataNascimento = motorista.DataNascimento,
                Cpf = motorista.Cpf,
                CarteiraDeHabilitacaoId = motorista.CarteiraDeHabilitacaoId,
                EmCorrida = motorista.EmCorrida,
            };

        public static IEnumerable<MotoristaDto> ToMotoristaDtos(this IEnumerable<Motorista> motoristas)
            => motoristas.Select(m => m.ToMotoristaDto());
    }
}
