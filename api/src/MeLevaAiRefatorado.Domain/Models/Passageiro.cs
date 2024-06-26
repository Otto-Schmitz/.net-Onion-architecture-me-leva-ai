﻿namespace MeLevaAiRefatorado.Domain.Models
{
    public class Passageiro : Pessoa
    {
        public List<Corrida> Corridas { get; init; } = new List<Corrida>();

        public bool EmCorrida { get; set; } = false;

        public Passageiro(string nome, string email, DateTime dataNascimento, string cpf)
            : base(nome, email, dataNascimento, cpf) { }

        public Passageiro Alterar(Passageiro passageiro)
        {
            Nome = passageiro.Nome;
            Email = passageiro.Email;
            DataNascimento = passageiro.DataNascimento;
            Cpf = passageiro.Cpf;

            return this;
        }

        public override bool VerificaIdadeMinima()
        {
            int idadeMinima = 16;
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - DataNascimento.Year;

            if (DataNascimento > dataAtual.AddYears(-idade))
                --idade;

            return idade >= idadeMinima;
        }

        public void AdicionarCorrida(Corrida corrida)
        {
            Corridas.Add(corrida);
        }

        public void RemoverCorrida(Corrida corrida)
        {
            Corridas.Remove(corrida);
        }

        public Corrida? ObterCorrida(Guid id)
            => Corridas.FirstOrDefault(v => v.CorridaId == id);
    }
}
