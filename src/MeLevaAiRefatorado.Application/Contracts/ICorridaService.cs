using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Application.Contracts
{
    public interface ICorridaService
    {
        ChamarCorridaDto Chamar(ChamarCorridaRequest request);
    }
}
