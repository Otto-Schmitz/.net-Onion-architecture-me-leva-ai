using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeLevaAiRefatorado.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarteiraDeHabilitacaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteiraDeHabilitacaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CarteiraDeHabilitacaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    EmCorrida = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    EmCorrida = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false),
                    FotoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeDeLugares = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    CorridaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PassageiroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PontoInicialX = table.Column<double>(type: "REAL", nullable: false),
                    PontoInicialY = table.Column<double>(type: "REAL", nullable: false),
                    PontoFinalX = table.Column<double>(type: "REAL", nullable: false),
                    PontoFinalY = table.Column<double>(type: "REAL", nullable: false),
                    TempoEstimadoChegada = table.Column<int>(type: "INTEGER", nullable: false),
                    TempoEstimadoDestino = table.Column<double>(type: "REAL", nullable: false),
                    ValorEstimado = table.Column<double>(type: "REAL", nullable: false),
                    StatusCorrida = table.Column<int>(type: "INTEGER", nullable: false),
                    MotoristaId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.CorridaId);
                    table.ForeignKey(
                        name: "FK_Corridas_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Corridas_Passageiros_PassageiroId",
                        column: x => x.PassageiroId,
                        principalTable: "Passageiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_MotoristaId",
                table: "Corridas",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_PassageiroId",
                table: "Corridas",
                column: "PassageiroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteiraDeHabilitacaos");

            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Passageiros");
        }
    }
}
