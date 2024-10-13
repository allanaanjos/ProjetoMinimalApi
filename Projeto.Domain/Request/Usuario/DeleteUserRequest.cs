using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Usuario
{
    public class DeleteUserRequest : Request
    {
       [Required(ErrorMessage = "O Id do usuário é obrigatório.")]
        public int UserId { get; set; }
    }
}