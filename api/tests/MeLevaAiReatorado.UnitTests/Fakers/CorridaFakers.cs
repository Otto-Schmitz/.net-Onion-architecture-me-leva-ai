using Bogus;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.UnitTests.Fakers
{
    public class CorridaFakers
    {
        public Faker<ChamarCorridaRequest> ChamarCorridaRequest = new Faker<ChamarCorridaRequest>("pt_BR")
            .RuleFor(p => p.PassageiroId, f => f.Random.Guid())
            .RuleFor(p => p.PontoInicialX, f => f.Random.Double())
            .RuleFor(p => p.PontoInicialY, f => f.Random.Double())
            .RuleFor(p => p.PontoFinalX, f => f.Random.Double())
            .RuleFor(p => p.PontoFinalY, f => f.Random.Double());
    }
}
