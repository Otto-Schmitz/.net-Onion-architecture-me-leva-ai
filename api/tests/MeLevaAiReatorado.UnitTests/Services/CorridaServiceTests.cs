using MeLevaAiReatorado.UnitTests.Fakers;
using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Application.Services;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.UnitTests.Fakers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.UnitTests.Services
{
    public class CorridaServiceTests
    {
        private readonly ICorridaService _corridaService;
        private readonly Mock<ICorridaRepository> _corridaRepository = new();
        private readonly Mock<IVeiculoRepository> _veiculoRepository = new();
        private readonly Mock<IMotoristaRepository> _motoristaRepository = new();
        private readonly Mock<IPassageiroRepository> _passageiroRepository = new();
        private readonly Mock<ICarteiraDeHabilitacaoRepository> _carteiraDeHabilitacaoRepository = new();
        private readonly CorridaFakers _corridaFakers = new();
        private readonly VeiculoFakers _veiculoFakers = new();
        private readonly MotoristaFakers _motoristaFakers = new();
        private readonly PassageiroFakers _passageiroFakers = new();

        public CorridaServiceTests()
        {
            _corridaService = new CorridaService(_corridaRepository.Object, _veiculoRepository.Object, _motoristaRepository.Object, _passageiroRepository.Object, _carteiraDeHabilitacaoRepository.Object);
        }

        //Chamar

        [Fact]
        public void Chamar_DeveChamamarCorretamente_QuandoCorreto()
        {
            var request = _corridaFakers.ChamarCorridaRequest.Generate();
            var veiculo = _veiculoFakers.Veiculo.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacao.Generate();
            var passageiro = _passageiroFakers.Passageiro.Generate();
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> { veiculo });
            _motoristaRepository.Setup(x => x.Obter(veiculo.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);
            _passageiroRepository.Setup(x => x.Obter(request.PassageiroId)).ReturnsAsync(passageiro);

            var response = _corridaService.Chamar(request);

            _corridaRepository.Verify(x => x.Adicionar(It.IsAny<Corrida>()), Times.Once);
            Assert.IsType<ChamarCorridaDto>(response);
        }

        [Fact]
        public void Chamar_DeveRetornarErro_QuandoNaoExistirVeiculo()
        {
            var request = _corridaFakers.ChamarCorridaRequest.Generate();
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> {  });

            var response = _corridaService.Chamar(request);

            _corridaRepository.Verify(x => x.Adicionar(It.IsAny<Corrida>()), Times.Never);
            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == "Nenhum veículo disponível foi encontrados."));
        }

        [Fact]
        public void Chamar_DeveRetornarErro_QuandoNaoExistirPassageiro()
        {
            var request = _corridaFakers.ChamarCorridaRequest.Generate();
            var veiculo = _veiculoFakers.Veiculo.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacao.Generate();
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> { veiculo });
            _motoristaRepository.Setup(x => x.Obter(veiculo.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);
            _passageiroRepository.Setup(x => x.Obter(request.PassageiroId)).ReturnsAsync((Passageiro)null);

            var response = _corridaService.Chamar(request);
            _corridaRepository.Verify(x => x.Adicionar(It.IsAny<Corrida>()), Times.Never);
            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == "Passageiro inválida."));
        }

        [Fact]
        public void Chamar_DeveRetornarErro_QuandoPassageiroEmCorrida()
        {
            var request = _corridaFakers.ChamarCorridaRequest.Generate();
            var veiculo = _veiculoFakers.Veiculo.Generate();
            var motorista = _motoristaFakers.Motorista.Generate();
            var carteira = _motoristaFakers.CarteiraDeHabilitacao.Generate();
            var passageiro = _passageiroFakers.Passageiro.Generate();
            passageiro.EmCorrida = true;
            _veiculoRepository.Setup(x => x.Listar()).ReturnsAsync(new List<Veiculo> { veiculo });
            _motoristaRepository.Setup(x => x.Obter(veiculo.MotoristaId)).ReturnsAsync(motorista);
            _carteiraDeHabilitacaoRepository.Setup(x => x.Obter(motorista.CarteiraDeHabilitacaoId)).ReturnsAsync(carteira);
            _passageiroRepository.Setup(x => x.Obter(request.PassageiroId)).ReturnsAsync(passageiro);

            var response = _corridaService.Chamar(request);

            _corridaRepository.Verify(x => x.Adicionar(It.IsAny<Corrida>()), Times.Never);
            Assert.NotNull(response);
            Assert.True(response.Notifications.Any(n => n.Message == "Passageiro em corrida."));
        }
    }
}
