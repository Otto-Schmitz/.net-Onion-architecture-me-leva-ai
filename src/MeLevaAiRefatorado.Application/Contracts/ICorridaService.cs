using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface ICorridaService
    {
        ChamarCorridaDto Chamar(ChamarCorridaRequest request);
    }
}
