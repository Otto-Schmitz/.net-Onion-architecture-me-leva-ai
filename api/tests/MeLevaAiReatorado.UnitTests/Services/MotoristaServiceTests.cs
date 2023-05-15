using MeLevaAiReatorado.UnitTests.Fakers;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Services;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using Moq;

namespace MeLevaAiReatorado.UnitTests.Services
{
    public class MotoristaServiceTests
    {
        private readonly IMotoristaService _motoristaService;
        private readonly Mock<IMotoristaRepository> _motoristaRepository = new();
        private readonly Mock<IVeiculoRepository> _veiculoRepository = new();
        private readonly Mock<ICarteiraDeHabilitacaoRepository> _carteiraDeHabilitacaoRepository = new();
        private readonly MotoristaFakers _motoristaFakers = new();
        private readonly VeiculoFakers _veiculoFakers = new();

        public MotoristaServiceTests()
        {
            _motoristaService = new MotoristaService(_motoristaRepository.Object, _veiculoRepository.Object, _carteiraDeHabilitacaoRepository.Object);
        }

        //Cadastrar

        [Fact]
        public void Cadastrar_DeveRetornarMotorista_QuandoCadastradoCorretamente()
        {
            var request = _motoristaFakers.AdicionarMotoristaRequest.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();

            var response = _motoristaService.Cadastrar(request);

            _motoristaRepository.Verify(x => x.Cadastrar(It.IsAny<Motorista>()), Times.Once);
            Assert.IsType<MotoristaDto>(response);
        }

        [Fact]
        public void Cadastrar_DeveRetornarErro_QuandoMotoristaForMenorQue18Anos()
        {
            var request = _motoristaFakers.AdicionarMotoristaMenorRequest.Generate();

            var expected = "Idade mínima é de 18 anos.";
            var response = _motoristaService.Cadastrar(request);

            _motoristaRepository.Verify(x => x.Cadastrar(It.IsAny<Motorista>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        [Fact]
        public void Cadastrar_DeveRetornarErro_QuandoCpfForInvalido()
        {
            var request = _motoristaFakers.AdicionarMotoristaRequest.Generate();
            request.Cpf = "";

            var expected = "Cpf inválido.";
            var response = _motoristaService.Cadastrar(request);

            _motoristaRepository.Verify(x => x.Cadastrar(It.IsAny<Motorista>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        [Fact]
        public void Cadastrar_DeveRetornarErro_QuandoCarteiraDeHabilitacaoExpirar()
        {
            var request = _motoristaFakers.AdicionarMotoristaCarteiraExpiradaRequest.Generate();


            var expected = "Carteira de motorista expirada.";
            var response = _motoristaService.Cadastrar(request);

            _motoristaRepository.Verify(x => x.Cadastrar(It.IsAny<Motorista>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        //Obter

        [Fact]
        public void Obter_DeveRetornarNotificacao_QuandoNaoEncontrado()
        {
            var id = Guid.NewGuid();
            _motoristaRepository.Setup(x => x.Obter(id)).ReturnsAsync((Motorista)null);

            var response = _motoristaService.Obter(id);

            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == $"Motorista com o id {id} não encontrado."));
        }

        [Fact]
        public void Obter_DeveRetornarMotoristaDto_QuandoMotoristaExistir()
        {
            var motorista = _motoristaFakers.Motorista.Generate();
            _motoristaRepository.Setup(x => x.Obter(motorista.Id)).ReturnsAsync(motorista);

            var response = _motoristaService.Obter(motorista.Id);

            Assert.NotNull(response);
            Assert.Equal(motorista.Id, response.Id);
            Assert.Equal(motorista.Nome, response.Nome);
            Assert.Equal(motorista.Email, response.Email);
            Assert.Equal(motorista.DataNascimento, response.DataNascimento);
            Assert.Equal(motorista.Cpf, response.Cpf);
        }

        //Remover

        [Fact]
        public void Remover_DeveRetornarErro_QuandoMotoristaNaoExistir()
        {
            var id = Guid.NewGuid();
            _motoristaRepository.Setup(x => x.Obter(id)).ReturnsAsync((Motorista)null);

            var response = _motoristaService.Remover(id);

            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == $"Motorista com o id {id} não encontrado."));
        }

        [Fact]
        public void Remover_DeveRetornarErro_QuandoVeiculoExistir()
        {
            var motorista = _motoristaFakers.Motorista.Generate();
            var veiculo = _veiculoFakers.Veiculo.Generate();
            _veiculoRepository.Setup(x => x.ObterPorMotorista(motorista.Id)).ReturnsAsync(veiculo);
            _motoristaRepository.Setup(x => x.Obter(motorista.Id)).ReturnsAsync(motorista);

            var response = _motoristaService.Remover(motorista.Id);

            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == $"Não é possível remover o motorista com o id {motorista.Id}, pois ele possui um veículo associado."));
        }

        [Fact]
        public void Remover_DeveRemoverMotorista_QuandoExistenteEVeiculoNaoExistir()
        {
            var motorista = _motoristaFakers.Motorista.Generate();
            _veiculoRepository.Setup(x => x.ObterPorMotorista(motorista.Id)).ReturnsAsync((Veiculo)null);
            _motoristaRepository.Setup(x => x.Obter(motorista.Id)).ReturnsAsync(motorista);

            var response = _motoristaService.Remover(motorista.Id);

            Assert.NotNull(response);
            Assert.IsType<MotoristaDto>(response);
            Assert.False(response.Notifications.Any());
            _motoristaRepository.Verify(repo => repo.Remover(motorista), Times.Once);
        }

        //Listar

        [Fact]
        public void Listar_DeveRetornarListaVazia_QuandoNaoHaMotoristas()
        {
            var expected = Enumerable.Empty<MotoristaDto>();

            var response = _motoristaService.Listar();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComUmMotorista_QuandoHaUmMotorista()
        {
            var motorista = _motoristaFakers.Motorista.Generate();
            _motoristaRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Motorista> { motorista });

            var expected = 1;
            var response = _motoristaService.Listar().Count();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComDoisMotoristas_QuandoHaMaisMotoristas()
        {
            var motorista1 = _motoristaFakers.Motorista.Generate();
            var motorista2 = _motoristaFakers.Motorista.Generate();
            _motoristaRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Motorista> { motorista1, motorista2 });

            var expected = 2;
            var response = _motoristaService.Listar().Count();

            Assert.Equal(expected, response);
        }
    }
}
