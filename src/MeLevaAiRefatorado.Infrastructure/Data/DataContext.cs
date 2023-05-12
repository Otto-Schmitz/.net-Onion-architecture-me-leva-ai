using MeLevaAiRefatorado.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLevaAiRefatorado.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Passageiro> Passageiros => Set<Passageiro>();

        public DbSet<Corrida> Corridas => Set<Corrida>();

        public DbSet<Motorista> Motoristas => Set<Motorista>();

        public DbSet<Veiculo> Veiculos => Set<Veiculo>();

        public DbSet<CarteiraDeHabilitacao> CarteiraDeHabilitacaos => Set<CarteiraDeHabilitacao>();
    }
}
