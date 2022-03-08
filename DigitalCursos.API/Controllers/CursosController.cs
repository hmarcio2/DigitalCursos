using DigitalCursos.API.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCursos()
        {
            try
            {
                var result = await _cursoRepository.GetCursos();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            try
            {
                var result = await _cursoRepository.GetCurso(id);
                if (result == null)
                {
                    return NotFound($"O Curso com id = {id} não foi localizado");
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> CreateCurso(Curso curso)
        {
            try
            {
                if (curso == null)
                {
                    return BadRequest();
                }
                var createdCurso = await _cursoRepository.AddCurso(curso);
                return CreatedAtAction(nameof(GetCurso),
                    new { id = createdCurso.CursoId }, createdCurso);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Curso>> UpdateCurso(int id, Curso curso)
        {
            try
            {
                if (id != curso.CursoId)
                {
                    return BadRequest($"O Curso com id={id} não confere com o aluno a ser atualizado");
                }
                var alunoToUpdate = await _cursoRepository.GetCurso(id);

                if (alunoToUpdate == null)
                {
                    return NotFound($"Curso com id = {id} não encontrado");
                }
                return await _cursoRepository.UpdateCurso(curso);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Curso>> DeleteAluno(int id)
        {
            try
            {
                var alunoToDelete = await _cursoRepository.GetCurso(id);
                if (alunoToDelete == null)
                {
                    return NotFound($"Curso com id = {id} não encontrado");
                }
                return await _cursoRepository.DeleteCurso(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao deletar os dados do banco de dados");
            }
        }
    }
}
