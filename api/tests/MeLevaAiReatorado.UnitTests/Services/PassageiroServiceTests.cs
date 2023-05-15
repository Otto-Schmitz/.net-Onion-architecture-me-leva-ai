using MeLevaAiReatorado.UnitTests.Fakers;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Services;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using Moq;

namespace MeLevaAiReatorado.UnitTests.Services
{
    public class PassageiroServiceTests
    {
        private readonly IPassageiroService _passageiroService;
        private readonly Mock<IPassageiroRepository> _passageiroRepository = new();
        private readonly PassageiroFakers _fakers = new();

        public PassageiroServiceTests()
        {
            _passageiroService = new PassageiroService(_passageiroRepository.Object); 
        }

        //Cadastrar

        [Fact]
        public void Cadastrar_DeveRetornarPassageiro_QuandoCriado() {
            var request = _fakers.AdicionarPassageiroRequest.Generate();
            var passageiro = _fakers.Passageiro.Generate();
            _passageiroRepository.Setup(x => x.ObterPorCpf(request.Cpf)).ReturnsAsync((Passageiro)null);

            var response = _passageiroService.Cadastrar(request);

            _passageiroRepository.Verify(x => x.Cadastrar(It.IsAny<Passageiro>()), Times.Once);
            Assert.IsType<PassageiroDto>(response);
        }

        [Fact]
        public void Cadastrar_NaoDeveCadastrarPassageiro_QuandoIdadeForMenorQue16Anos()
        {
            var request = _fakers.AdicionarPassageiroMenorRequest.Generate();

            var expected = "Idade mínima é de 16 anos.";
            var response = _passageiroService.Cadastrar(request);

            _passageiroRepository.Verify(x => x.Cadastrar(It.IsAny<Passageiro>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        [Fact]
        public void Cadastrar_NaoDeveCadastrarPassageiro_QuandoCpfJaExiste()
        {
            var request = _fakers.AdicionarPassageiroRequest.Generate();
            var passageiro = _fakers.Passageiro.Generate();
            _passageiroRepository.Setup(x => x.ObterPorCpf(request.Cpf)).ReturnsAsync(passageiro);

            var expected = "Passageiro já existe.";
            var result = _passageiroService.Cadastrar(request);

            _passageiroRepository.Verify(x => x.Cadastrar(It.IsAny<Passageiro>()), Times.Never);
            Assert.Single(result.Notifications);
            Assert.Equal(expected, result.Notifications.First().Message);
        }

        [Fact]
        public void Cadastrar_NaoDeveCadastrarPassageiro_QuandoCpfForInvalido()
        {
            var request = _fakers.AdicionarPassageiroRequest.Generate();
            request.Cpf = "12345678900";

            var expected = "Cpf inválido.";
            var response = _passageiroService.Cadastrar(request);

            _passageiroRepository.Verify(x => x.Cadastrar(It.IsAny<Passageiro>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        //Obter

        [Fact]
        public void Obter_DeveRetornarNotificacaoPassageiroNaoEncontrado_QuandoNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _passageiroRepository.Setup(x => x.Obter(id)).ReturnsAsync((Passageiro)null);

            var response = _passageiroService.Obter(id);

            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == $"Passageiro com o id {id} não encontrado."));
        }

        [Fact]
        public void Obter_DeveRetornarPassageiroDto_QuandoPassageiroExistir()
        {
            var passageiro = _fakers.Passageiro.Generate();
            _passageiroRepository.Setup(x => x.Obter(passageiro.Id)).ReturnsAsync(passageiro);

            var response = _passageiroService.Obter(passageiro.Id);

            Assert.NotNull(response);
            Assert.Equal(passageiro.Id, response.Id);
            Assert.Equal(passageiro.Nome, response.Nome);
            Assert.Equal(passageiro.Email, response.Email);
            Assert.Equal(passageiro.DataNascimento, response.DataNascimento);
            Assert.Equal(passageiro.Cpf, response.Cpf);
        }

        //Remover

        [Fact]
        public void Remover_DeveRetornarErro_QuandoPassageiroNaoExistir()
        {
            var id = Guid.NewGuid();
            _passageiroRepository.Setup(repo => repo.Obter(id)).ReturnsAsync((Passageiro)null);

            var response = _passageiroService.Remover(id);

            Assert.NotNull(response);
            Assert.IsType<PassageiroDto>(response);
            Assert.True(response.Notifications.Any());
            Assert.Contains(response.Notifications, n => n.Message.Contains($"Passageiro com o id {id} não encontrado."));
            _passageiroRepository.Verify(repo => repo.Remover(It.IsAny<Passageiro>()), Times.Never);
        }

        [Fact]
        public void Remover_DeveRemoverPassageiro_QuandoExistente()
        {
            var passageiro = _fakers.Passageiro.Generate();
            _passageiroRepository.Setup(repo => repo.Obter(passageiro.Id)).ReturnsAsync(passageiro);

            var response = _passageiroService.Remover(passageiro.Id);

            Assert.NotNull(response);
            Assert.IsType<PassageiroDto>(response);
            Assert.False(response.Notifications.Any());
            _passageiroRepository.Verify(repo => repo.Remover(passageiro), Times.Once);
        }

        //Listar

        [Fact]
        public void Listar_DeveRetornarListaVazia_QuandoNaoHaPassageiros()
        {
            var expected = Enumerable.Empty<PassageiroDto>();

            var response = _passageiroService.Listar();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComUmPassageiro_QuandoHaUmPassageiro()
        {
            var passageiro = _fakers.Passageiro.Generate();
            _passageiroRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Passageiro> { passageiro });

            var expected = 1;
            var response = _passageiroService.Listar().Count();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComDoisPassageiros_QuandoHaMaisPassageiros()
        {
            var passageiro1 = new PassageiroFakers().Passageiro.Generate();
            var passageiro2 = new PassageiroFakers().Passageiro.Generate();
            _passageiroRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Passageiro> { passageiro1, passageiro2 });

            var expected = 2;
            var response = _passageiroService.Listar().Count();

            Assert.Equal(expected, response);
        }
    }
}
