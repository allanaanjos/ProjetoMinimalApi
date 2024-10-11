using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Request.Usuario
{
    public class GetUserByIdRequest : Request
    {

        [Required(ErrorMessage = "Id Inválido")]
        public int UserId { get; set; }
    }
}