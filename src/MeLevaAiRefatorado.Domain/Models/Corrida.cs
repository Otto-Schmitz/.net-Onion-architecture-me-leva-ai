using MeLevaAiRefatorado.Domain.Models.Enuns;

namespace MeLevaAiRefatorado.Domain.Models
{
    public class Corrida
    {
        public Guid CorridaId { get; init; } = Guid.NewGuid();

        public Guid PassageiroId { get; private set; }

        public Guid VeiculoId { get; private set; }

        public double PontoInicialX { get; private set; }

        public double PontoInicialY { get; private set; }

        public double PontoFinalX { get; private set; }

        public double PontoFinalY { get; private set; }

        public int TempoEstimadoChegada { get; init; } = new Random().Next(5, 10);

        public double TempoEstimadoDestino { get; private set; }

        public double ValorEstimado { get; private set; }


        public StatusCorrida StatusCorrida { get; private set; } = StatusCorrida.Solicitada;

        public Corrida(Guid passageiroId, Guid veiculoId, double pontoInicialX, double pontoInicialY, double pontoFinalX, double pontoFinalY)
        {
            PassageiroId = passageiroId;
            VeiculoId = veiculoId;
            PontoInicialX = pontoInicialX;
            PontoInicialY = pontoInicialY;
            PontoFinalX = pontoFinalX;
            PontoFinalY = pontoFinalY;
        }

        public void AtualizarValorEstimado(double valor)
        {
            ValorEstimado = valor;
        }

        public void AtualizarTempoEstimadoDestino(double tempo)
        {
            TempoEstimadoDestino = tempo;
        }

        public void AtualizarStatusCorrida(StatusCorrida statusCorrida)
        {
            StatusCorrida = statusCorrida;
        }
    }
}
