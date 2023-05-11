using System.ComponentModel.DataAnnotations;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa
{
    public class ValorRequest
    {
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public double Valor { get; set; }
    }
}
