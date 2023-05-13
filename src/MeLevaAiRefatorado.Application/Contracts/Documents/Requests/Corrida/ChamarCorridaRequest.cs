using System.ComponentModel.DataAnnotations;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida
{
    public class ChamarCorridaRequest
    {
        [Required(ErrorMessage = "O campo PassageiroId é obrigatório.")]
        public Guid PassageiroId { get; set; }

        [Required(ErrorMessage = "O campo PontoInicial é obrigatório.")]
        public double PontoInicialX { get; set; }

        [Required(ErrorMessage = "O campo PontoInicial é obrigatório.")]
        public double PontoInicialY { get; set; }

        [Required(ErrorMessage = "O campo PontoFinal é obrigatório.")]
        public double PontoFinalX { get; set; }

        [Required(ErrorMessage = "O campo PontoFinal é obrigatório.")]
        public double PontoFinalY { get; set; }
    }
}
