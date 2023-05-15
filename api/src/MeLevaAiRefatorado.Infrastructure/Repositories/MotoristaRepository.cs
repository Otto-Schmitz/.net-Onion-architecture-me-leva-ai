using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly DataContext _context;

        public MotoristaRepository(DataContext context)
        {
            _context = context; 
        }

        public async Task<IEnumerable<Motorista>> Listar()
            => await _context.Motoristas.ToListAsync();

        public async Task<Motorista?> Obter(Guid? id)
            => await _context.Motoristas.FindAsync(id);

        public async Task<Motorista?> ObterPorCpf(string cpf)
            => await _context.Motoristas.Where(p => p.Cpf.Contains(cpf)).FirstOrDefaultAsync();

        public async Task<Motorista> Cadastrar(Motorista motorista)
        {
            _context.Motoristas.Add(motorista);
            await _context.SaveChangesAsync();

            return motorista;
        }

        public async Task<Motorista> Remover(Motorista motorista)
        {
            _context.Remove(motorista);
            await _context.SaveChangesAsync();
            
            return motorista;
        }
    }
}
