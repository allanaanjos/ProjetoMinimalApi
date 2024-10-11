using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Usuario
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido.")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string? Senha { get; set; } 
    }
}
