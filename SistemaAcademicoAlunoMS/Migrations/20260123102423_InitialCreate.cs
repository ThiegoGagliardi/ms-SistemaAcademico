using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAcademicoAlunoMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Curso_Discplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeDisciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiglaDisciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    MediaFinal = table.Column<decimal>(type: "Decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Curso_Discplina", x => new { x.AlunoId, x.DisciplinaId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aluno_Curso_Discplina_Nota",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    Bimestre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Data = table.Column<DateOnly>(type: "Date", nullable: false),
                    Nota = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Peso = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno_Curso_Discplina_Nota", x => new { x.AlunoId, x.DisciplinaId, x.CursoId, x.Bimestre });
                    table.ForeignKey(
                        name: "FK_Aluno_Curso_Discplina_Nota_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matricula_Aluno_Curso",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "Date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "Date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula_Aluno_Curso", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_Curso_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno_Curso_Discplina");

            migrationBuilder.DropTable(
                name: "Aluno_Curso_Discplina_Nota");

            migrationBuilder.DropTable(
                name: "Matricula_Aluno_Curso");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
