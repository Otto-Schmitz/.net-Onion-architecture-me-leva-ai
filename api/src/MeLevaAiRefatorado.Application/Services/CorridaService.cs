using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
using MeLevaAiRefatorado.Application.Mappers;
using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Application.Services
{
    public class CorridaService : ICorridaService
    {
        private readonly ICorridaRepository _corridaRepository;

        private readonly IVeiculoRepository _veiculoRepository;

        private readonly IMotoristaRepository _motoristaRepository;

        private readonly IPassageiroRepository _passageiroRepository;

        private readonly ICarteiraDeHabilitacaoRepository _carteiraDeHabilitacaoRepository;

        public CorridaService(ICorridaRepository corridaRepository, IVeiculoRepository veiculoRepository, IMotoristaRepository motoristaRepository, IPassageiroRepository passageiroRepository, ICarteiraDeHabilitacaoRepository carteiraDeHabilitacaoRepository)
        {
            _corridaRepository = corridaRepository;
            _veiculoRepository = veiculoRepository;
            _motoristaRepository = motoristaRepository;
            _passageiroRepository = passageiroRepository;
            _carteiraDeHabilitacaoRepository = carteiraDeHabilitacaoRepository;
        }

        public ChamarCorridaDto Chamar(ChamarCorridaRequest request)
        {
            var response = new ChamarCorridaDto();
            var veiculo = ChamarVeiculo();

            if (veiculo == null)
            {
                response.AddNotification(new Notification("Nenhum veículo disponível foi encontrados."));
                return response;
            }

            var motorista = _motoristaRepository.Obter(veiculo.MotoristaId).Result;

            var passageiro = _passageiroRepository.Obter(request.PassageiroId).Result;

            if (passageiro == null)
            {
                response.AddNotification(new Notification("Passageiro inválida."));
                return response;
            }
            if (passageiro.EmCorrida)
            {
                response.AddNotification(new Notification("Passageiro em corrida."));
                return response;
            }
            if (motorista == null)
            {
                response.AddNotification(new Notification("Motorista inválida."));
                return response;
            }
            if (motorista.EmCorrida)
            {
                response.AddNotification(new Notification("Motorista em corrida."));
                return response;
            }

            var corrida = request.ToCorrida(passageiro, veiculo);

            _corridaRepository.Adicionar(corrida);
            passageiro.AdicionarCorrida(corrida);
            motorista.AdicionarCorrida(corrida);
            passageiro.IniciarCorrida();
            motorista.IniciarCorrida();

            return corrida.ToChamarCorridaDto(veiculo);
        }

        private Veiculo? ChamarVeiculo()
        {
            var veiculos = _veiculoRepository.Listar().Result.ToArray();

            foreach (var veiculo in veiculos)
            {
                var motorista = _motoristaRepository.Obter(veiculo.MotoristaId.GetValueOrDefault()).Result;
                var carteira = _carteiraDeHabilitacaoRepository.Obter(motorista.CarteiraDeHabilitacaoId).Result;

                if (motorista == null)
                    return null;

                if (carteira == null)
                    return null;

                if (carteira.DataVencimento < DateTime.Now)
                    return null;

                if (motorista.EmCorrida)
                    return null;

                return veiculo;
            }
            return null;
        }
    }
}
