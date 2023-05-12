using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Mappers;
using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;

namespace MeLevaAiRefatorado.Application.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ICarteiraDeHabilitacaoRepository _carteiraDeHabilitacaoRepository;

        public MotoristaService(IMotoristaRepository motoristaRepository, IVeiculoRepository veiculoRepository, ICarteiraDeHabilitacaoRepository carteiraDeHabilitacaoRepository)
        {
            _motoristaRepository = motoristaRepository;
            _veiculoRepository = veiculoRepository;
            _carteiraDeHabilitacaoRepository = carteiraDeHabilitacaoRepository;
        }

        public MotoristaDto Adicionar(AdicionarMotoristaRequest request)
        {
            var novoMotorista = request.ToMotorista();

            var response = new MotoristaDto();

            if (!novoMotorista.VerificaIdadeMinima())
            {
                response.AddNotification(new Notification("Idade mínima é de 18 anos."));
                return response;
            }

            if (!novoMotorista.VerificaCpf())
            {
                response.AddNotification(new Notification("Cpf inválido."));
                return response;
            }

            if (request.CarteiraDeHabilitacao.DataVencimento > DateTime.Now)
            {
                response.AddNotification(new Notification("Carteira de motorista expirada."));
                return response;
            }

            _carteiraDeHabilitacaoRepository.Adicionar(request.CarteiraDeHabilitacao);
            _motoristaRepository.Cadastrar(novoMotorista);

            return novoMotorista.ToMotoristaDto();
        }

        public IEnumerable<MotoristaDto> Listar()
        {
            return _motoristaRepository.Listar().ToMotoristaDtos();
        }

        public MotoristaDto Obter(Guid id)
        {
            var response = new MotoristaDto();
            var motorista = _motoristaRepository.Obter(id);

            if (motorista == null)
            {
                response.AddNotification(new Notification($"Motorista com o id {id} não encontrado."));
                return response;
            }

            return motorista.ToMotoristaDto();
        }

        public MotoristaDto Remover(Guid id)
        {
            var response = new MotoristaDto();

            var motorista = _motoristaRepository.Obter(id);

            if (motorista == null)
            {
                response.AddNotification(new Notification($"Motorista com o id {id} não encontrado."));
                return response;
            }

            var veiculo = _veiculoRepository.ObterPorMotorista(id);

            if (veiculo != null)
            {
                response.AddNotification(new Notification($"Não é possível remover o motorista com o id {id}, pois ele possui um veículo associado."));
                return response;
            }

            _motoristaRepository.Remover(id);

            return response;
        }
    }
}
