using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Curso
{
    public class GetCursoByIdRequest : Request
    {
        [Required(ErrorMessage = "O ID do curso é obrigatório.")]
        public int CursoId { get; set; }
    }
}
