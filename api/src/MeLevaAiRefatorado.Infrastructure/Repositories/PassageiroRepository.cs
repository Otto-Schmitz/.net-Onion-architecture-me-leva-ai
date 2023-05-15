using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class PassageiroRepository : IPassageiroRepository
    {
        private readonly DataContext _context;

        public PassageiroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Passageiro>> Listar()
            => await _context.Passageiros.ToListAsync();

        public async Task<Passageiro?> Obter(Guid? id)
            => await _context.Passageiros.FindAsync(id);

        public async Task<Passageiro?> ObterPorCpf(string cpf)
            => await _context.Passageiros.Where(p => p.Cpf.Contains(cpf)).FirstOrDefaultAsync();

        public async Task<Passageiro> Cadastrar(Passageiro passageiro)
        {
            _context.Passageiros.Add(passageiro);
            await _context.SaveChangesAsync();

            return passageiro;
        }

        public async Task<Passageiro> Remover(Passageiro passageiro)
        {
            _context.Passageiros.Remove(passageiro);
            await _context.SaveChangesAsync();

            return passageiro;
        }
    }
}
