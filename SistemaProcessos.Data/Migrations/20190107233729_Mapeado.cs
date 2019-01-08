using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaProcessos.Data.Migrations
{
    public partial class Mapeado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(15)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumProcesso = table.Column<string>(type: "varchar(15)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    IdEmpresa = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processo_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processo_IdEmpresa",
                table: "Processo",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processo");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
