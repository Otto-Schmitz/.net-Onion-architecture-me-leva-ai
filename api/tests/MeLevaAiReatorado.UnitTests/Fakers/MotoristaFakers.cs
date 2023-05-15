using Bogus;
using Bogus.Extensions.Brazil;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Domain.Models.Enuns;

namespace MeLevaAiReatorado.UnitTests.Fakers
{
    public class MotoristaFakers
    {
        public Faker<Motorista> Motorista = new Faker<Motorista>("pt_BR")
            .CustomInstantiator(f
            => new Motorista(f.Name.FullName(), f.Internet.ExampleEmail("exemplo"), f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-25)), f.Person.Cpf(false), f.Random.Guid()));

        public Faker<Motorista> MotoristaMenor = new Faker<Motorista>("pt_BR")
            .CustomInstantiator(f
            => new Motorista(f.Name.FullName(), f.Internet.ExampleEmail("exemplo"), f.Date.Between(DateTime.Now.AddYears(-17), DateTime.Now.AddYears(-1)), f.Person.Cpf(false), f.Random.Guid()));

        public Faker<AdicionarMotoristaRequest> AdicionarMotoristaRequest = new Faker<AdicionarMotoristaRequest>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.ExampleEmail("exemplo"))
            .RuleFor(p => p.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-25)))
            .RuleFor(p => p.Cpf, f => f.Person.Cpf(false))
            .RuleFor(p => p.Numero, f => new Random().Next(111111111, 999999999).ToString())
            .RuleFor(p => p.Categoria, f => Categoria.A)
            .RuleFor(p => p.DataVencimento, f => f.Date.Between(DateTime.Now.AddYears(1), DateTime.Now.AddYears(4)));

        public Faker<AdicionarMotoristaRequest> AdicionarMotoristaMenorRequest = new Faker<AdicionarMotoristaRequest>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.ExampleEmail("exemplo"))
            .RuleFor(p => p.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-17), DateTime.Now.AddYears(-1)))
            .RuleFor(p => p.Cpf, f => f.Person.Cpf(false))
            .RuleFor(p => p.Numero, f => new Random().Next(111111111, 999999999).ToString())
            .RuleFor(p => p.Categoria, f => Categoria.A)
            .RuleFor(p => p.DataVencimento, f => f.Date.Between(DateTime.Now.AddYears(1), DateTime.Now.AddYears(4)));

        public Faker<AdicionarMotoristaRequest> AdicionarMotoristaCarteiraExpiradaRequest = new Faker<AdicionarMotoristaRequest>("pt_BR")
            .RuleFor(p => p.Nome, f => f.Name.FullName())
            .RuleFor(p => p.Email, f => f.Internet.ExampleEmail("exemplo"))
            .RuleFor(p => p.DataNascimento, f => f.Date.Between(DateTime.Now.AddYears(-18), DateTime.Now.AddYears(-30)))
            .RuleFor(p => p.Cpf, f => f.Person.Cpf(false))
            .RuleFor(p => p.Numero, f => new Random().Next(111111111, 999999999).ToString())
            .RuleFor(p => p.Categoria, f => Categoria.A)
            .RuleFor(p => p.DataVencimento, f => f.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(-4)));

        public Faker<CarteiraDeHabilitacao> CarteiraDeHabilitacao = new Faker<CarteiraDeHabilitacao>("pt_BR")
            .CustomInstantiator(f
            => new CarteiraDeHabilitacao(new Random().Next(111111111, 999999999).ToString(), Categoria.A, DateTime.Now.AddYears(1)));

        public Faker<CarteiraDeHabilitacao> CarteiraDeHabilitacaoExpirada = new Faker<CarteiraDeHabilitacao>("pt_BR")
            .CustomInstantiator(f
            => new CarteiraDeHabilitacao(new Random().Next(111111111, 999999999).ToString(), Categoria.A, DateTime.Now.AddYears(-1)));
    }
}
