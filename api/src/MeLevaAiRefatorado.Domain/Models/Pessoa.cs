﻿namespace MeLevaAiRefatorado.Domain.Models
{
    public abstract class Pessoa
    {
        protected Pessoa(string nome, string email, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }

        public Guid Id { get; init; } = Guid.NewGuid();

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public bool EmCorrida { get; private set; } = false;

        public abstract bool VerificaIdadeMinima();

        public bool VerificaCpf()
        {
            return CpfLibrary.Cpf.Check(Cpf);
        }

        public void IniciarCorrida()
        {
            EmCorrida = true;
        }

        public void FinalizarCorrida()
        {
            EmCorrida = false;
        }

    }
}
