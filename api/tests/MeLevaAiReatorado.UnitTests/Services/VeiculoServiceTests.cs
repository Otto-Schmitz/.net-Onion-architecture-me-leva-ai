using MeLevaAiReatorado.UnitTests.Fakers;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Application.Services;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using Moq;

namespace MeLevaAiRefatorado.UnitTests.Services
{
    public class VeiculoServiceTests
    {
        private readonly IVeiculoService _veiculoService;
        private readonly Mock<IVeiculoRepository> _veiculoRepository = new();
        private readonly Mock<IMotoristaRepository> _motorisaRepository = new();
        private readonly Mock<ICarteiraDeHabilitacaoRepository> _carteiraDeHabilitacaoRepository = new();
        private readonly VeiculoFakers _veiculoFakers = new();
        private readonly MotoristaFakers _motoristaFakers = new();

        public VeiculoServiceTests()
        {
            _veiculoService = new VeiculoService(_veiculoRepository.Object, _motorisaRepository.Object, _carteiraDeHabilitacaoRepository.Object);
        }

        //Cadastrar

        [Fact]
        public void Cadastrar_DeveRetornarVeiculo_QuandoCadastrado()
        {
            var request = _veiculoFakers.AdicionarVeiculoRequest.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacao.Generate();
            _motorisaRepository.Setup(x => x.Obter(request.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);

            var response = _veiculoService.Cadastrar(request);

            _veiculoRepository.Verify(x => x.Adicionar(It.IsAny<Veiculo>()), Times.Once);
            Assert.IsType<VeiculoDto>(response);
        }

        [Fact]
        public void Cadastar_DeveRetornarErro_QuandoMotoristaNaoEncontrado()
        {
            var request = _veiculoFakers.AdicionarVeiculoRequest.Generate();
            _motorisaRepository.Setup(x => x.Obter(request.MotoristaId)).ReturnsAsync((Motorista)null);

            var expected = $"Motorista com o id {request.MotoristaId} não encontrado.";
            var response = _veiculoService.Cadastrar(request);

            _veiculoRepository.Verify(x => x.Adicionar(It.IsAny<Veiculo>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        [Fact]
        public void Cadastar_DeveRetornarErro_QuandoCategoriaNaoCompativel()
        {
            var request = _veiculoFakers.AdicionarVeiculoRequest.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacao.Generate();
            carteira.Categoria = Domain.Models.Enuns.Categoria.B;
            _motorisaRepository.Setup(x => x.Obter(request.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);

            var expected = "A categoria do veículo não é compatível com a categoria da carteira de habilitação do motorista.";
            var response = _veiculoService.Cadastrar(request);

            _veiculoRepository.Verify(x => x.Adicionar(It.IsAny<Veiculo>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        [Fact]
        public void Cadastar_DeveRetornarErro_QuandoCarteiraExpirada()
        {
            var request = _veiculoFakers.AdicionarVeiculoRequest.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacaoExpirada.Generate();
            _motorisaRepository.Setup(x => x.Obter(request.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);

            var expected = "A carteira de habilitação está expirada.";
            var response = _veiculoService.Cadastrar(request);

            _veiculoRepository.Verify(x => x.Adicionar(It.IsAny<Veiculo>()), Times.Never);
            Assert.Single(response.Notifications);
            Assert.Equal(expected, response.Notifications.First().Message);
        }

        //Obter

        [Fact]
        public void Obter_DeveRetornarErro_QuandoVeiculoNaoEncontrado()
        {
            var id = Guid.NewGuid();

            var response = _veiculoService.Obter(id);

            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == $"Veículo com o id {id} não encontrado."));
        }

        [Fact]
        public void Obter_DeveRetornarVeiculo_QuandoEncontrado()
        {
            var veiculo = _veiculoFakers.Veiculo.Generate();
            _veiculoRepository.Setup(x => x.Obter(veiculo.Id)).ReturnsAsync(veiculo);

            var response = _veiculoService.Obter(veiculo.Id);

            Assert.NotNull(response);
            Assert.Equal(veiculo.Id, response.Id);
            Assert.Equal(veiculo.Marca, response.Marca);
            Assert.Equal(veiculo.Placa, response.Placa);
            Assert.Equal(veiculo.Modelo, response.Modelo);
        }

        //Remover

        [Fact]
        public void Remover_DeveRetornarErro_QuandoVeiculoNaoExistir()
        {
            var id = Guid.NewGuid();
            _veiculoRepository.Setup(repo => repo.Obter(id)).ReturnsAsync((Veiculo)null);

            var response = _veiculoService.Remover(id);

            Assert.NotNull(response);
            Assert.IsType<VeiculoDto>(response);
            Assert.True(response.Notifications.Any());
            Assert.Contains(response.Notifications, n => n.Message.Contains($"Veículo com o id {id} não encontrado."));
            _veiculoRepository.Verify(repo => repo.Remover(It.IsAny<Veiculo>()), Times.Never);
        }

        [Fact]
        public void Remover_DeveRemoverVeiculo_QuandoExistir()
        {
            var veiculo = _veiculoFakers.Veiculo.Generate();
            _veiculoRepository.Setup(repo => repo.Obter(veiculo.Id)).ReturnsAsync(veiculo);

            var response = _veiculoService.Remover(veiculo.Id);

            Assert.NotNull(response);
            Assert.IsType<VeiculoDto>(response);
            Assert.False(response.Notifications.Any());
            _veiculoRepository.Verify(repo => repo.Remover(veiculo), Times.Once);
        }

        //Listar

        [Fact]
        public void Listar_DeveRetornarListaVazia_QuandoNaoExistirVeiculos()
        {
            var expected = Enumerable.Empty<VeiculoDto>();

            var response = _veiculoService.Listar();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComVeiculo_QuandoExistirVeiculos()
        {
            var veiculo = _veiculoFakers.Veiculo.Generate();
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> { veiculo });

            var expected = 1;
            var response = _veiculoService.Listar().Count();

            Assert.Equal(expected, response);
        }

        [Fact]
        public void Listar_DeveRetornarListaComVeiculos_QuandoExistirVeiculos()
        {
            var veiculo1 = _veiculoFakers.Veiculo.Generate();
            var veiculo2 = _veiculoFakers.Veiculo.Generate();
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> { veiculo1, veiculo2 });

            var expected = 2;
            var response = _veiculoService.Listar().Count();

            Assert.Equal(expected, response);
        }
    }
}
