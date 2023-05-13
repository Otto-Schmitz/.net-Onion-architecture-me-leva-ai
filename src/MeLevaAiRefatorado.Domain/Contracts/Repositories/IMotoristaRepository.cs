using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IMotoristaRepository
    {
        Task<IEnumerable<Motorista>> Listar();

        Task<Motorista?> Obter(Guid? id);

        Task<Motorista?> ObterPorCpf(string cpf);

        Task<Motorista> Cadastrar(Motorista motorista);

        Task<Motorista> Remover(Motorista motorista);
    }
}
