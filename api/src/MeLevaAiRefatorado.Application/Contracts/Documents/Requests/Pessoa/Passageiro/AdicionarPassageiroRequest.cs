﻿using System.ComponentModel.DataAnnotations;

namespace MeLevaAiRefatorado.Application.Contracts.Documents.Requests.Pessoa.Passageiro
{
    public class AdicionarPassageiroRequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo Email deve ter no máximo 100 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Data Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Cpf é obrigatório.")]
        public string Cpf { get; set; }
    }
}
