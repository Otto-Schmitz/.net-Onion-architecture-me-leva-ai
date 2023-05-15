using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Veiculo;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Veiculo;
using MeLevaAiRefatorado.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Application.Mappers
{
    public static class VeiculoMapper
    {
        public static Veiculo ToVeiculo(this AdicionarVeiculoRequest request)
            => new(request.MotoristaId, request.Placa, request.Marca, request.Modelo, request.Ano, request.Cor, request.FotoUrl, request.QuantidadeDeLugares, request.Categoria);

        public static VeiculoDto ToVeiculoDto(this Veiculo veiculo)
            => new()
            {
                Id = veiculo.Id,
                MotoristaId = veiculo.MotoristaId,
                Placa = veiculo.Placa,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Cor = veiculo.Cor,
                FotoUrl = veiculo.FotoUrl
            };

        public static IEnumerable<VeiculoDto> ToVeiculoDto(this IEnumerable<Veiculo> veiculos)
            => veiculos.Select(v => v.ToVeiculoDto());
    }
}
