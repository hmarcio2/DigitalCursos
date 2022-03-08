using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCursos.Models.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage="Informe o nome do Aluno")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome do Aluno")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe o email do Aluno")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento do Aluno")]
        public DateTime Nascimento { get; set; }
        public byte[]? Foto { get; set; }
        public Genero Genero { get; set; }
        public Curso? Curso { get; set; }
        public int CursoId { get; set; }

    }
}
