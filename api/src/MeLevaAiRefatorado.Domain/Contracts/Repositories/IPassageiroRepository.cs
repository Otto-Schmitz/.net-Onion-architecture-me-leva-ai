using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IPassageiroRepository
    {
        Task<IEnumerable<Passageiro>> Listar();

        Task<Passageiro?> Obter(Guid? id);

        Task<Passageiro?> ObterPorCpf(string cpf);

        Task<Passageiro> Cadastrar(Passageiro passageiro);

        Task<Passageiro> Remover(Passageiro passageiro);
    }
}
