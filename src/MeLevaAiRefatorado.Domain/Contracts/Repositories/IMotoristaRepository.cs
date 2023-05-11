using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IMotoristaRepository
    {
        IEnumerable<Motorista> Listar();

        Motorista? Obter(Guid? id);

        Motorista? ObterPorCpf(string cpf);

        void Cadastrar(Motorista motorista);

        bool Remover(Guid id);
    }
}
