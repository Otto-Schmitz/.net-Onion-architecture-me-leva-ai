using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Passageiro;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface IPassageiroService
    {
        PassageiroDto Cadastrar(AdicionarPassageiroRequest request);

        IEnumerable<PassageiroDto> Listar();

        PassageiroDto Obter(Guid id);

        public PassageiroDto Remover(Guid id);
    }
}
