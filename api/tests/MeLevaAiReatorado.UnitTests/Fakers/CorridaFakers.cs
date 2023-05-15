using Bogus;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;

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
