using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly DataContext _context;

        public VeiculoRepository(DataContext context) { 
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> Listar()
            => await _context.Veiculos.ToListAsync();

        public async Task<Veiculo?> Obter(Guid id)
            => await _context.Veiculos.FindAsync(id);

        public async Task<Veiculo> Adicionar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo); 
            await _context.SaveChangesAsync();  

            return veiculo;
        }

        public async Task<Veiculo> Remover(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return veiculo;
        }

        public async Task<Veiculo> Atualizar(Veiculo veiculo)
        {
            Remover(veiculo);
            Adicionar(veiculo);

            return veiculo;
        }

        public async Task<Veiculo?> ObterPorMotorista(Guid motoristaId)
            => await _context.Veiculos.FindAsync(motoristaId);
    }
}
