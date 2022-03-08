using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Método utilizado para limitar ou definir uma coluna no campo de dados
            
            // CURSO

            // Como padrão a coluna string tem tamanho Var(Max) ocupando muito espaço
            // por isso é importante limitar o tamanho para melhor gerenciar a memória
            mb.Entity<Curso>()
                .Property(c => c.CursoNome)
                .HasMaxLength(150);
            mb.Entity<Curso>()
                .Property(c => c.Descricao)
                .HasMaxLength(256);
            // Também é possível fazer isso com números.
            // exemplo de definição de números flutuantes
            mb.Entity<Curso>()
                .Property(c => c.Preco)
                .HasColumnType("decimal(18,2)");

            // ALUNO
            mb.Entity<Aluno>()
                .Property(c => c.Nome)
                .HasMaxLength(150);
            mb.Entity<Aluno>()
                .Property(c => c.Sobrenome)
                .HasMaxLength(150);
            mb.Entity<Aluno>()
                .Property(c => c.Email)
                .HasMaxLength(100);

            // DADOS
            // Também é possível inicializar um banco de dados com dados dentro
            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 1,
                    CursoNome = "CSharp Basico",
                    Descricao = "Curso de C# Básico",
                    CargaHoraria = 40,
                    Inicio = new DateTime(2020, 07, 01),
                    Preco = 150.00M,
                    Logo = null
                });

            mb.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = 2,
                    CursoNome = "ASP NET CORE Básico",
                    Descricao = "Curso ASP NET CORE Básico",
                    CargaHoraria = 40,
                    Inicio = new DateTime(2020, 08, 01),
                    Preco = 250.00M,
                    Logo = null
                });

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 1,
                    Nome = "Felipe",
                    Sobrenome = "Ribeiro",
                    Email = "felipe@email.com",
                    Nascimento = new DateTime(2002, 07, 11),
                    Foto = null,
                    Genero = Genero.Masculino,
                    CursoId = 1
                });

            mb.Entity<Aluno>().HasData(
                new Aluno
                {
                    AlunoId = 2,
                    Nome = "Maria",
                    Sobrenome = "Silveira",
                    Email = "maria@email.com",
                    Nascimento = new DateTime(2001, 05, 07),
                    Foto = null,
                    Genero = Genero.Feminino,
                    CursoId = 2
                });
        }

    }
}
