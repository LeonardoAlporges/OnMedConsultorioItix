using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnMed.Infra.Data.Migrations.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Nacimento = table.Column<DateTime>(nullable: false),
                    DataConsultaInicial = table.Column<DateTime>(nullable: false),
                    DataConsultaFinal = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
