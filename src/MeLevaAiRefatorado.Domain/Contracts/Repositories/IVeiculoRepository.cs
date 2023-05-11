using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface IVeiculoRepository
    {
        IEnumerable<Veiculo> Listar();

        Veiculo? Obter(Guid id);

        void Adicionar(Veiculo veiculo);

        bool Remover(Guid id);

        void Atualizar(Veiculo veiculo);

        Veiculo? ObterPorMotorista(Guid motoristaId);

        Veiculo? ObterAleatorio();
    }
}
