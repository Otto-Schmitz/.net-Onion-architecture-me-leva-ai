//using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
//using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
//using MeLevaAiRefatorado.Application.Validations.Core;
//using MeLevaAiRefatorado.Domain.Contracts.Repositories;
//using MeLevaAiRefatorado.Domain.Models;

//namespace MeLevaAiRefatorado.Application.Services
//{
//    public class CorridaService
//    {
//        private readonly ICorridaRepository _corridaRepository;

//        private readonly IVeiculoRepository _veiculoRepository;

//        private readonly IMotoristaRepository _motoristaRepository;

//        private readonly IPassageiroRepository _passageiroRepository;

//        private readonly double VALOR_POR_SEGUNDO = 0.2;

//        private readonly double VELOCIDADE_EM_KMH = 30;

//        private readonly double SEGUNDOS_EM_1H = 60 * 60;

//        private readonly double NOTA_MINIMA = 1;

//        private readonly double NOTA_MAXIMA = 5;

//        public CorridaService(ICorridaRepository corridaRepository, IVeiculoRepository veiculoRepository, IMotoristaRepository motoristaRepository, IPassageiroRepository passageiroRepository)
//        {
//            _corridaRepository = corridaRepository;
//            _veiculoRepository = veiculoRepository;
//            _motoristaRepository = motoristaRepository;
//            _passageiroRepository = passageiroRepository;
//        }

//        public ChamarCorridaDto Chamar(ChamarCorridaRequest request)
//        {
//            var response = new ChamarCorridaDto();

//            var veiculo = ChamarVeiculo();

//            if (veiculo == null)
//            {
//                response.AddNotification(new Notification("Nenhum veículo disponível foi encontrados."));
//                return response;
//            }

//            var motorista = _motoristaRepository.Obter(veiculo.MotoristaId);

//            var passageiro = _passageiroRepository.Obter(request.PassageiroId);

//            if (passageiro == null)
//            {
//                response.AddNotification(new Notification("Passageiro inválida."));
//                return response;
//            }
//            if (passageiro.EmCorrida)
//            {
//                response.AddNotification(new Notification("Passageiro em corrida."));
//                return response;
//            }

//            var corrida = request.ToCorrida(passageiro, veiculo);

//            _corridaRepository.Adicionar(corrida);
//            passageiro.AdicionarCorrida(corrida);
//            motorista.AdicionarCorrida(corrida);
//            passageiro.IniciarCorrida();
//            motorista.IniciarCorrida();

//            response = corrida.ToChamarCorridaDto();

//            return response;
//        }

//        private Veiculo? ChamarVeiculo()
//        {
//            var veiculos = _veiculoRepository.Listar().ToArray();

//            foreach (var veiculo in veiculos)
//            {
//                var motorista = _motoristaRepository.Obter(veiculo.MotoristaId.GetValueOrDefault());

//                if (motorista == null)
//                    return null;

//                if (motorista.CarteiraDeHabilitacao.DataVencimento < DateTime.Now)
//                    return null;

//                if (motorista.EmCorrida)
//                    return null;

//                return veiculo;
//            }

//            return null;
//        }
//    }
//}
