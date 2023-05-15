using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface IVeiculoService
    {
        VeiculoDto Cadastrar(AdicionarVeiculoRequest request);

        IEnumerable<VeiculoDto> Listar();

        VeiculoDto Obter(Guid id);

        VeiculoDto Remover(Guid id);
    }
}
