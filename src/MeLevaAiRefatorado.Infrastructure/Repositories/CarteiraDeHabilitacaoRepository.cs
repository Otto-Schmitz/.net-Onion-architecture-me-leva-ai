using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Infrastructure.Repositories
{
    public class CarteiraDeHabilitacaoRepository : ICarteiraDeHabilitacaoRepository
    {
        private static readonly List<CarteiraDeHabilitacao> _carteiras= new();

        public void Adicionar(CarteiraDeHabilitacao carteira)
        {
            _carteiras.Add(carteira);
        }

        public CarteiraDeHabilitacao? Obter(Guid id)
        {
            return _carteiras.FirstOrDefault(c => c.Id == id);
        }
    }
}
