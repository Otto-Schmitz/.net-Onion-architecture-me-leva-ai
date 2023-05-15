using MeLevaAiRefatorado.Domain.Models.Enuns;
using System.ComponentModel.DataAnnotations;

namespace MeLevaAiRefatorado.Domain.Models
{
    public class CarteiraDeHabilitacao
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Numero { get; set; }

        [EnumDataType(typeof(Categoria), ErrorMessage = "O campo Categoria deve ser um valor válido.")]
        public Categoria Categoria { get; set; }
        public DateTime DataVencimento { get; set; }

        public CarteiraDeHabilitacao(string numero, Categoria categoria, DateTime dataVencimento)
        {
            Numero = numero;
            Categoria = categoria;
            DataVencimento = dataVencimento;
        }
    }
}
