using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;

namespace MeLevaAiRefatorado.Application.Services
{
    public class MotoristaService : IMotoristaService
    {
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public MotoristaService(IMotoristaRepository motoristaRepository, IVeiculoRepository veiculoRepository)
        {
            _motoristaRepository = motoristaRepository;
            _veiculoRepository = veiculoRepository;
        }

        public MotoristaDto Adicionar(AdicionarMotoristaRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MotoristaDto> Listar()
        {
            throw new NotImplementedException();
        }

        public MotoristaDto Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public MotoristaDto Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public MotoristaDto DepositarSaldo(Guid id, ValorRequest request)
        {
            throw new NotImplementedException();
        }

        public MotoristaDto SacarSaldo(Guid id, ValorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
