using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalCursos.API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoNome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CargaHoraria", "CursoNome", "Descricao", "Inicio", "Logo", "Preco" },
                values: new object[] { 1, 40, "CSharp Basico", "Curso de C# Básico", new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 150.00m });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "CargaHoraria", "CursoNome", "Descricao", "Inicio", "Logo", "Preco" },
                values: new object[] { 2, 40, "ASP NET CORE Básico", "Curso ASP NET CORE Básico", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 250.00m });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "CursoId", "Email", "Foto", "Genero", "Nascimento", "Nome", "Sobrenome" },
                values: new object[] { 1, 1, "felipe@email.com", null, 0, new DateTime(2002, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felipe", "Ribeiro" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "CursoId", "Email", "Foto", "Genero", "Nascimento", "Nome", "Sobrenome" },
                values: new object[] { 2, 2, "maria@email.com", null, 1, new DateTime(2001, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "Silveira" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
