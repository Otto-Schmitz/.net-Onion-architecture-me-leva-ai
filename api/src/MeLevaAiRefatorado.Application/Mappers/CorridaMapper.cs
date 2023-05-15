using MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida;
using MeLevaAiRefatorado.Application.Contracts.Documents.Responses.Corrida;
using MeLevaAiRefatorado.Domain.Models;

namespace MeLevaAiRefatorado.Application.Mappers
{
    public static class CorridaMapper
    {
        public static Corrida ToCorrida(this ChamarCorridaRequest request, Passageiro passageiro, Veiculo veiculo)
         => new(passageiro.Id, veiculo.Id, request.PontoInicialX, request.PontoInicialY, request.PontoFinalX, request.PontoFinalY);

        public static CorridaDto ToCorridaDto(this Corrida corrida, Passageiro passageiro, Motorista motorista, Veiculo veiculo)
            => new()
            {
                Id = corrida.CorridaId,
                NomePassageiro = passageiro.Nome,
                NomeMotorista = motorista.Nome,
                Veiculo = veiculo.ToVeiculoDto(),
                TempoEstimando = corrida.TempoEstimadoChegada
            };

        public static ChamarCorridaDto ToChamarCorridaDto(this Corrida corrida, Veiculo veiculo)
            => new()
            {
                CorridaID = corrida.CorridaId,
                Veiculo = veiculo.ToVeiculoDto(),
                TempoEstimado = corrida.TempoEstimadoChegada,
            };
    }
}
