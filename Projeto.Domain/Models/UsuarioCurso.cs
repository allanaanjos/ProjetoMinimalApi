namespace Projeto.Domain.Models
{
    public class UsuarioCurso
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public int CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
    }
}