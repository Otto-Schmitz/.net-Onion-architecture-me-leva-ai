using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Motorista;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Pessoa.Motorista;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface IMotoristaService
    {
        IEnumerable<MotoristaDto> Listar();

        MotoristaDto Obter(Guid id);

        MotoristaDto Adicionar(AdicionarMotoristaRequest request);

        MotoristaDto Remover(Guid id);
    }
}
