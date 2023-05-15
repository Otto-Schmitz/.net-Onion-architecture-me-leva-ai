using Bogus;
using Bogus.Extensions.UnitedKingdom;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Domain.Models.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeLevaAiReatorado.UnitTests.Fakers
{
    public class VeiculoFakers
    {
        public Faker<AdicionarVeiculoRequest> AdicionarVeiculoRequest = new Faker<AdicionarVeiculoRequest>("pt_BR")
            .RuleFor(p => p.MotoristaId, f => Guid.NewGuid())
            .RuleFor(p => p.Placa, f => "BRA2E23")
            .RuleFor(p => p.Marca, f => f.Vehicle.Manufacturer())
            .RuleFor(p => p.Modelo, f => "Model")
            .RuleFor(p => p.Ano, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(-25)).Year)
            .RuleFor(p => p.Cor, f => "Preto")
            .RuleFor(p => p.QuantidadeDeLugares, f => 4)
            .RuleFor(p => p.Categoria, f => Categoria.A);

        public readonly Faker<Veiculo> Veiculo = new Faker<Veiculo>("pt_BR")
            .CustomInstantiator(f
            => new Veiculo(Guid.NewGuid(), "BRA2E23", f.Vehicle.Manufacturer(), "Model", f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(-25)).Year, "Preto", null, 4, Categoria.A));
    }
}
