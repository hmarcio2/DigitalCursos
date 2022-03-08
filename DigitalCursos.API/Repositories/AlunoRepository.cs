using DigitalCursos.API.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.API.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;
        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            var result = await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(c=> c.AlunoId == id);
            if(aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return aluno;
            }
            return null;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            return await _context.Alunos
                .FirstOrDefaultAsync(c => c.AlunoId == id);
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            var result = _context.Alunos.FirstOrDefault(c => c.AlunoId == aluno.AlunoId);
            if(result != null)
            {
                result.Nome = aluno.Nome;
                result.Sobrenome = aluno.Sobrenome;
                result.Email = aluno.Email;
                result.Nascimento = aluno.Nascimento;
                result.Foto = aluno.Foto;
                result.Genero = aluno.Genero;
                result.CursoId = aluno.CursoId;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
