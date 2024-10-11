using Projeto.Domain.Models;
using Projeto.Domain.Request.Usuario;

namespace Projeto.Domain.Handler
{
    public interface IUsuarioHandler
    {
        Task<Response<Usuario?>> CreateUser(CreateUserRequest request);
        Task<Response<Usuario?>> UpdateUser(UpdateUserRequest rquest);
        Task<Response<Usuario?>> DeleteUser(DeleteUserRequest request);
        Task<Response<Usuario?>> GetUserById(GetUserByIdRequest request);
        Task<Response<List<Usuario>?>> GetAllUser(GetAllUserRequest request);
    }
}