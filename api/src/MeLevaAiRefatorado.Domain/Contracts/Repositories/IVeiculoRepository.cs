using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> Listar();

        Task<Veiculo?> Obter(Guid id);

        Task<Veiculo> Adicionar(Veiculo veiculo);

        Task<Veiculo> Remover(Veiculo veiculo);

        Task<Veiculo> Atualizar(Veiculo veiculo);

        Task<Veiculo?> ObterPorMotorista(Guid motoristaId);
    }
}
