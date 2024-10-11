using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Usuario
{
    public class DeleteUserRequest : Request
    {
       [Required(ErrorMessage = "O Id do usuário é obrigatório.")]
        public override string Id { get; set; } = string.Empty;
    }
}