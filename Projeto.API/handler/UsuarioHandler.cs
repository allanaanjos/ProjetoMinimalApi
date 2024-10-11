using Projeto.Domain.Handler;
using Projeto.Domain.Models;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.handler
{
    public class UsuarioHandler : IUsuarioHandler
    {
        public Task<Response<Usuario?>> CreateUser(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> DeleteUser(DeleteUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<Usuario>?>> GetAllUser(GetAllUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> GetUserById(GetUserByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Usuario?>> UpdateUser(UpdateUserRequest rquest)
        {
            throw new NotImplementedException();
        }
    }
}