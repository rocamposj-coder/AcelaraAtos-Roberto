using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFluent.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    cargaHoraria = table.Column<int>(type: "INT", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    dataRegistro = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorDisciplina",
                columns: table => new
                {
                    DisciplinaId = table.Column<long>(type: "bigint", nullable: false),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorDisciplina", x => new { x.DisciplinaId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_ProfDisci_DisciplinaID",
                        column: x => x.DisciplinaId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfDisci_ProfessorID",
                        column: x => x.ProfessorId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDisciplina_ProfessorId",
                table: "ProfessorDisciplina",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorDisciplina");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Disciplina");
        }
    }
}
