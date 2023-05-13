using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Mappers;
using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;

namespace MeLevaAiRefatorado.Application.Services
{
    public class PassageiroService : IPassageiroService 
    {
        private readonly IPassageiroRepository _passageiroRepository;

        public PassageiroService(IPassageiroRepository passageiroRepository)
        {
            _passageiroRepository = passageiroRepository;
        }

        public PassageiroDto Cadastrar(AdicionarPassageiroRequest request)
        {
            var novoPassageiro = request.ToPassageiro();
            var response = new PassageiroDto();

            if (!novoPassageiro.VerificaIdadeMinima())
            {
                response.AddNotification(new Notification("Idade mínima é de 16 anos."));
                return response;
            }

            if (!novoPassageiro.VerificaCpf())
            {
                response.AddNotification(new Notification("Cpf inválido."));
                return response;
            }

            if (_passageiroRepository.ObterPorCpf(novoPassageiro.Cpf).Result != null)
            {
                response.AddNotification(new Notification("Passageiro já existe."));
                return response;
            }

            _passageiroRepository.Cadastrar(novoPassageiro);

            return novoPassageiro.ToPassageiroDto();
        }

        public IEnumerable<PassageiroDto> Listar()
        {
            return _passageiroRepository.Listar().Result.ToPassageiroDto();
        }

        public PassageiroDto Obter(Guid id)
        {
            var response = new PassageiroDto();
            var passageiro = _passageiroRepository.Obter(id).Result;

            if (passageiro == null)
            {
                response.AddNotification(new Notification($"Passageiro com o id {id} não encontrado."));
                return response;
            }

            return passageiro.ToPassageiroDto();
        }

        public PassageiroDto Remover(Guid id)
        {
            var response = new PassageiroDto();

            var passageiro = _passageiroRepository.Obter(id).Result;

            if (passageiro == null)
            {
                response.AddNotification(new Notification($"Passageiro com o id {id} não encontrado."));
                return response;
            }

            _passageiroRepository.Remover(passageiro);

            return passageiro.ToPassageiroDto();
        }
    }
}
