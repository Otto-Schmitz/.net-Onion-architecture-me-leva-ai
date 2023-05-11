using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface ICorridaRepository
    {
        IEnumerable<Corrida> Listar();

        Corrida? Obter(Guid id);

        void Adicionar(Corrida corrida);

        void Alterar(Corrida corrida);

        bool Remover(Guid id);
    }
}
