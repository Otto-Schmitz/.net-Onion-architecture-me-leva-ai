using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface ICorridaRepository
    {
        Task<IEnumerable<Corrida>> Listar();

        Task<Corrida?> Obter(Guid id);

        Task<Corrida> Adicionar(Corrida corrida);

        Task<Corrida> Alterar(Corrida corrida);

        Task<Corrida> Remover(Corrida corrida);
    }
}
