using DigitalCursos.Models.Models;

namespace DigitalCursos.API.Repositories
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task<Curso> GetAlunoCurso(int id);
        Task<Curso> AddCurso(Curso curso);
        Task<Curso> UpdateCurso(Curso curso);
        Task<Curso> DeleteCurso(int id);
    }
}
