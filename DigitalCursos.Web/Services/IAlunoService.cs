using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<Aluno> UpdateAluno(Aluno alunoAtualizado);
        Task<Aluno> CreateAluno(Aluno alunoNovo);
        Task DeleteAluno(int id);
    }
}
