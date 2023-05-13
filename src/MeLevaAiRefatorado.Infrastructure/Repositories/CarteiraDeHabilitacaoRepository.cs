using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using MeLevaAiRefatorado.Infrastructure.Data;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class CarteiraDeHabilitacaoRepository : ICarteiraDeHabilitacaoRepository
    {
        private readonly DataContext _context;

        public CarteiraDeHabilitacaoRepository(DataContext context)
        {
            _context = context;
        }   

        public async Task<CarteiraDeHabilitacao> Adicionar(CarteiraDeHabilitacao carteira)
        {
            _context.CarteiraDeHabilitacaos.Add(carteira);
            await _context.SaveChangesAsync();

            return carteira;
        }

        public async Task<CarteiraDeHabilitacao?> Obter(Guid id)
            => await _context.CarteiraDeHabilitacaos.FindAsync(id);
    }
}
