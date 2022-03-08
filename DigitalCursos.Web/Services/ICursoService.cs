using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task<Curso> UpdateCurso(Curso cursoAtualizado);
        Task<Curso> CreateCurso(Curso cursoNovo);
        Task DeleteCurso(int id);
    }
}
