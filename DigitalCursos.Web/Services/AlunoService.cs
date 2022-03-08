using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public class AlunoService : IAlunoService
    {
        private HttpClient _httpClient { get; set; }
        public AlunoService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<Aluno> CreateAluno(Aluno alunoNovo)
        {
            var response = await _httpClient.PostAsJsonAsync<Aluno>("api/alunos", alunoNovo);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();
            return content;
        }

        public async Task DeleteAluno(int id)
        {
            await _httpClient.DeleteAsync($"api/alunos/{id}");
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _httpClient.GetFromJsonAsync<Aluno>($"api/alunos/{id}");
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<Aluno>>("api/alunos");
            return alunos;
        }

        public async Task<Aluno> UpdateAluno(Aluno alunoAtualizado)
        {
            var response = await _httpClient.PutAsJsonAsync<Aluno>($"api/alunos/{alunoAtualizado.AlunoId}", alunoAtualizado);
            var content = await response.Content.ReadFromJsonAsync<Aluno>();
            return content;
        }
    }
}
