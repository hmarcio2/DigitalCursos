using DigitalCursos.API.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRespoditory;
        public AlunosController(IAlunoRepository alunoRepository)
        {
            _alunoRespoditory = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAlunos()
        {
            try
            {
                var result = await _alunoRespoditory.GetAlunos();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var result = await _alunoRespoditory.GetAluno(id);
                if (result == null)
                {
                    return NotFound($"O aluno com id = {id} não foi localizado");
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
        public async Task<ActionResult<Aluno>> CreateAluno(Aluno aluno)
        {
            try
            {
                if(aluno == null)
                {
                    return BadRequest();
                }
                var createdAluno = await _alunoRespoditory.AddAluno(aluno);
                return CreatedAtAction(nameof(GetAluno),
                    new { id = createdAluno.AlunoId }, createdAluno);
            }            
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> UpdateAluno(int id, Aluno aluno)
        {
            try
            {
                if(id != aluno.AlunoId)
                {
                    return BadRequest($"O aluno com id={id} não confere com o aluno a ser atualizado");
                }
                var alunoToUpdate = await _alunoRespoditory.GetAluno(id);

                if(alunoToUpdate == null)
                {
                    return NotFound($"Aluno com id = {id} não encontrado");
                }
                return await _alunoRespoditory.UpdateAluno(aluno);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            try
            {
                var alunoToDelete = await _alunoRespoditory.GetAluno(id);
                if(alunoToDelete == null)
                {
                    return NotFound($"Aluno com id = {id} não encontrado");
                }
                return await _alunoRespoditory.DeleteAluno(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao deletar os dados do banco de dados");
            }
        }

    }
}
