using System.ComponentModel.DataAnnotations;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Corrida
{
    internal class FinalizarCorridaRequest
    {
        [Required(ErrorMessage = "O campo CorridaId é obrigatório.")]
        public Guid CorridaId { get; set; }
    }
}
