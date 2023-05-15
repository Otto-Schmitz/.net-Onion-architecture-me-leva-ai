using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Bogus;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro;
using Bogus.Extensions.Brazil;
using MeLevaAiRefatorado.Domain.Models;
using Bogus.DataSets;
using CpfLibrary;
using MeLevaAiRefatorado.Application.Mappers;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa;

namespace MeLevaAiReatorado.UnitTests.Fakers
{
    public class PassageiroFakers
    {
        public readonly Faker<AdicionarPassageiroRequest> AdicionarPassageiroRequest = new Faker<AdicionarPassageiroRequest>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.ExampleEmail("exemplo"))
            .RuleFor(p => p.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-25)))
            .RuleFor(p => p.Cpf, f => f.Person.Cpf(false));

        public readonly Faker<AdicionarPassageiroRequest> AdicionarPassageiroMenorRequest = new Faker<AdicionarPassageiroRequest>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.ExampleEmail("exemplo"))
            .RuleFor(p => p.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-17), DateTime.Now.AddYears(-10)))
            .RuleFor(p => p.Cpf, f => f.Person.Cpf(false));

        public readonly Faker<Passageiro> Passageiro = new Faker<Passageiro>("pt_BR")
            .CustomInstantiator(f 
            => new Passageiro(f.Name.FullName(), f.Internet.ExampleEmail("exemplo"), f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-25)), f.Person.Cpf(false)));

        public readonly Faker<PassageiroDto> PassageiroDto = new Faker<PassageiroDto>("pt_BR")
            .CustomInstantiator(f
            => new()
            {
                Id = Guid.NewGuid(),
                Nome = f.Name.FullName(),
                Email = f.Internet.ExampleEmail("exemplo"),
                DataNascimento = f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-25)),
                Cpf = f.Person.Cpf(false),
                EmCorrida = false
            });
    }
}