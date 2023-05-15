using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class CorridaRepository : ICorridaRepository
    {
        private readonly DataContext _context;

        public CorridaRepository(DataContext context)
        { 
            _context = context;
        }

        public async Task<IEnumerable<Corrida>> Listar()
            => await _context.Corridas.ToListAsync();

        public async Task<Corrida?> Obter(Guid id)
            => await _context.Corridas.FindAsync(id);

        public async Task<Corrida> Adicionar(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
            await _context.SaveChangesAsync();

            return corrida;
        }

        public async Task<Corrida> Alterar(Corrida corrida)
        {
            Remover(corrida);
            Adicionar(corrida);

            return corrida;
        }

        public async Task<Corrida> Remover(Corrida corrida)
        {
            _context.Corridas.Remove(corrida);
            await _context.SaveChangesAsync();  

            return corrida; 
        }
    }
}
