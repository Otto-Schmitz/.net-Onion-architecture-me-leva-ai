using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface IVeiculoService
    {
        VeiculoDto Cadastrar(AdicionarVeiculoRequest request);

        IEnumerable<VeiculoDto> Listar();

        VeiculoDto Obter(Guid id);

        VeiculoDto Remover(Guid id);
    }
}
