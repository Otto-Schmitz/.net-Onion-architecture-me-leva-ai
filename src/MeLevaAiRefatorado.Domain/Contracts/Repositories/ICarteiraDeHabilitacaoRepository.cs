using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Domain.Contracts.Repositories
{
    public interface ICarteiraDeHabilitacaoRepository
    {
        CarteiraDeHabilitacao Obter(Guid id);

        void Adicionar(CarteiraDeHabilitacao carteira);
    }
}
