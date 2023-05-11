using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Application.Mappers
{
    public static class PassageiroMapper
    {
        public static Passageiro ToPassageiro(this AdicionarPassageiroRequest request)
            => new(request.Nome, request.Email, request.DataNascimento, request.Cpf);

        public static Passageiro ToAlterarPassageiro(this AlterarPassageiroRequest request)
            => new(request.Nome, request.Email, request.DataNascimento, request.Cpf);


        public static PassageiroDto ToPassageiroDto(this Passageiro passageiro)
            => new()
            {
                Id = passageiro.Id,
                Nome = passageiro.Nome,
                Email = passageiro.Email,
                DataNascimento = passageiro.DataNascimento,
                Cpf = passageiro.Cpf,
                Saldo = passageiro.Saldo,
                EmCorrida = passageiro.EmCorrida,
            };

        public static IEnumerable<PassageiroDto> ToPassageiroDto(this IEnumerable<Passageiro> passageiros)
            => passageiros.Select(p => p.ToPassageiroDto());
    }
}
