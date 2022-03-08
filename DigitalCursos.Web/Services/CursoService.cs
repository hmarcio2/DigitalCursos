using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
    public class CursoService : ICursoService
    {
        private HttpClient _httpClient { get; set; }
        public CursoService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Curso> CreateCurso(Curso cursoNovo)
        {
            var response = await _httpClient.PostAsJsonAsync<Curso>("api/cursos", cursoNovo);
            var content = await response.Content.ReadFromJsonAsync<Curso>();
            return content;
        }

        public async Task DeleteCurso(int id)
        {
            await _httpClient.DeleteAsync($"api/cursos/{id}");
        }

        public async Task<Curso> GetCurso(int id)
        {
            var curso = await _httpClient.GetFromJsonAsync<Curso>($"api/cursos/{id}");
            return curso;
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            var cursos = await _httpClient.GetFromJsonAsync<IEnumerable<Curso>>("api/cursos");
            return cursos;
        }

        public async Task<Curso> UpdateCurso(Curso cursoAtualizado)
        {
            var response = await _httpClient.PutAsJsonAsync<Curso>($"api/cursos/{cursoAtualizado.CursoId}", cursoAtualizado);
            var content = await response.Content.ReadFromJsonAsync<Curso>();
            return content;
        }
    }
}
