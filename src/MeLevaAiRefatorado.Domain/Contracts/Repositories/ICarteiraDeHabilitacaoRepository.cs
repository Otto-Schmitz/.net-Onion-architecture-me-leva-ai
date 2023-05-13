using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface ICarteiraDeHabilitacaoRepository
    {
        Task<CarteiraDeHabilitacao> Obter(Guid id);

        Task<CarteiraDeHabilitacao> Adicionar(CarteiraDeHabilitacao carteira);
    }
}
