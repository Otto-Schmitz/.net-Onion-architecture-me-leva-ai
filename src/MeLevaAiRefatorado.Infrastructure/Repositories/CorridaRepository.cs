using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class CorridaRepository : ICorridaRepository
    {
        private static readonly List<Corrida> _corridas = new();

        public IEnumerable<Corrida> Listar()
            => _corridas;

        public Corrida? Obter(Guid id)
            => _corridas.FirstOrDefault(v => v.CorridaId == id);

        public void Adicionar(Corrida corrida)
        {
            _corridas.Add(corrida);
        }

        public void Alterar(Corrida corrida)
        {
            Remover(corrida.CorridaId);
            Adicionar(corrida);
        }

        public bool Remover(Guid id)
        {
            var corrida = Obter(id);

            if (corrida == null)
                return false;

            return _corridas.Remove(corrida);
        }
    }
}
