using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Curso
{
    public class UpdateCursoRquest : Request
    {
        [Required(ErrorMessage = "Id Inválido")]
        public int CursoId { get; set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do curso deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [StringLength(500, ErrorMessage = "A descrição do curso deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "A duração do curso é obrigatória.")]
        public TimeSpan DuracaoDoCurso { get; set; }

        [Url(ErrorMessage = "A URL da imagem deve ser válida.")]
        public string? ImgUrl { get; set; } = string.Empty;

    }
}