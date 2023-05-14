using MeLevaAiRefatorado.Application.Contracts;
using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Application.Mappers;
using MeLevaAiRefatorado.Application.Validations.Core;
using MeLevaAiRefatorado.Domain.Contracts.Repositories;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        private readonly IMotoristaRepository _motoristaRepository;

        private readonly ICarteiraDeHabilitacaoRepository _carteiraDeHabilitacaoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMotoristaRepository motoristaRepository, ICarteiraDeHabilitacaoRepository carteiraDeHabilitacaoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _motoristaRepository = motoristaRepository;
            _carteiraDeHabilitacaoRepository = carteiraDeHabilitacaoRepository;
        }

        public VeiculoDto Cadastrar(AdicionarVeiculoRequest request)
        {
            var novoVeiculo = request.ToVeiculo();
            var motorista = _motoristaRepository.Obter(request.MotoristaId).Result;
            

            if (motorista == null)
            {
                var response = new VeiculoDto();
                response.AddNotification(new Notification($"Motorista com o id {request.MotoristaId} não encontrado."));
                return response;
            }

            var carteira = _carteiraDeHabilitacaoRepository.Obter(motorista.CarteiraDeHabilitacaoId).Result;

            if (!VerificarCategoria(novoVeiculo, carteira))
            {
                var response = new VeiculoDto();
                response.AddNotification(new Notification("A categoria do veículo não é compatível com a categoria da carteira de habilitação do motorista."));
                return response;
            }

            if (!VerificaCarteira(carteira))
            {
                var response = new VeiculoDto();
                response.AddNotification(new Notification("A carteira de habilitação está expirada."));
                return response;
            }

            _veiculoRepository.Adicionar(novoVeiculo);

            return novoVeiculo.ToVeiculoDto();
        }

        public IEnumerable<VeiculoDto> Listar()
        {
            return _veiculoRepository.Listar().Result.ToVeiculoDto();
        }

        public VeiculoDto Obter(Guid id)
        {
            var response = new VeiculoDto();
            var veiculo = _veiculoRepository.Obter(id).Result;

            if (veiculo == null)
            {
                response.AddNotification(new Notification($"Veículo com o id {id} não encontrado."));

                return response;
            }

            return veiculo.ToVeiculoDto();
        }

        public VeiculoDto Remover(Guid id)
        {
            var response = new VeiculoDto();
            var veiculo = _veiculoRepository.Obter(id).Result;

            if (veiculo == null)
            {
                response.AddNotification(new Notification($"Veículo com o id {id} não encontrado."));

                return response;
            }

            _veiculoRepository.Remover(veiculo);

            return veiculo.ToVeiculoDto();
        }

        public static bool VerificarCategoria(Veiculo veiculo, CarteiraDeHabilitacao carteira)
        {
            return veiculo.Categoria == carteira.Categoria;
        }

        public static bool VerificaCarteira(CarteiraDeHabilitacao carteira)
        {
            return carteira.DataVencimento > DateTime.Now;
        }
    }
}
