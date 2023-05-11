using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IPassageiroRepository
    {
        IEnumerable<Passageiro> Listar();

        Passageiro? Obter(Guid? id);

        Passageiro? ObterPorCpf(string cpf);

        Passageiro Cadastrar(Passageiro passageiro);

        bool Remover(Guid id);
    }
}
