using DigitalCursos.API.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.API.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Curso> AddCurso(Curso curso)
        {
            var result = await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Curso> DeleteCurso(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.CursoId == id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return curso;
            }
            return null;
        }

        public async Task<Curso> GetAlunoCurso(int id)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.CursoId == id);
        }

        public async Task<Curso> GetCurso(int id)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(c => c.CursoId == id);
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _context.Cursos.AsNoTracking().ToListAsync();
        }

        public async Task<Curso> UpdateCurso(Curso curso)
        {
            var result = _context.Cursos.FirstOrDefault(c => c.CursoId == curso.CursoId);
            if (result != null)
            {
                result.CursoNome = curso.CursoNome;
                result.Descricao = curso.Descricao;
                result.Alunos = curso.Alunos;
                result.CargaHoraria = curso.CargaHoraria;
                result.Inicio = curso.Inicio;
                result.Logo = curso.Logo;
                result.Preco = curso.Preco;                 
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
