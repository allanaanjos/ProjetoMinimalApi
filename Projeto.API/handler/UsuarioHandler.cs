using Projeto.Domain.Handler;
using Projeto.Domain.IRepository;
using Projeto.Domain.Models;
using Projeto.Domain.Request.Usuario;


namespace Projeto.API.handler
{
    public class UsuarioHandler : IUsuarioHandler
    {
        private readonly IUsuarioRepository repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response<Usuario?>> CreateUser(CreateUserRequest request)
        {
            try
            {

                var user = new Usuario(
                  request.Nome,
                  request.Email,
                  BCrypt.Net.BCrypt.HashPassword(request.Senha)
                );

                await repository.AddAsync(user);

                return new Response<Usuario?>
                {
                    Data = user,
                    Message = "Usuário criado com sucesso"
                };
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>
                {
                    Data = null,
                    Message = $"Erro ao criar usuário: {ex.Message}"
                };
            }
        }

        public async Task<Response<Usuario?>> DeleteUser(DeleteUserRequest request)
        {
            try
            {
                var usuario = await repository.GetByIdAsync(request.UserId);

                if (usuario == null)
                {
                    return new Response<Usuario?>
                    { Data = null, Message = "Usuário não encontrado." };
                }

                await repository.DeleteAsync(usuario);

                return new Response<Usuario?>
                { Data = usuario, Message = "Usuário deletado com sucesso." };
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>
                { Data = null, Message = $"Erro ao deletar o usuário: {ex.Message}" };
            }
        }

        public async Task<Response<List<Usuario>?>> GetAllUser(GetAllUserRequest request)
        {
            try
            {
                var data = await repository.GetAllAsync();

                if (data == null || !data.Any())
                {
                    return new Response<List<Usuario>?>
                    { Data = null, Message = "Usuários não encontrados." };
                }

                return new Response<List<Usuario>?>
                { Data = data, Message = "Usuários recuperados com sucesso." };
            }
            catch (Exception ex)
            {
                return new Response<List<Usuario>?>
                { Data = null, Message = $"Erro no servidor: {ex.Message}" };
            }
        }


        public async Task<Response<Usuario?>> GetUserById(GetUserByIdRequest request)
        {
            try
            {
                var user = await repository.GetByIdAsync(request.UserId);

                if (user is null)
                    return new Response<Usuario?>
                     (data: null, message: "Usuário não encontrado.");

                return new Response<Usuario?>(data: user);
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>
                 (data: null, message: $"Erro no servidor: {ex.Message}");
            }
        }

        public async Task<Response<Usuario?>> UpdateUser(UpdateUserRequest request)
        {
            try
            {
                
                var userUpdate = await repository.GetByIdAsync(request.Id);

                if (userUpdate is null)
                    return new Response<Usuario?>
                    (data: null, message: "Usuário não encontrado.");

                userUpdate.Nome = request.Nome ?? userUpdate.Nome;
                userUpdate.Email = request.Email ?? userUpdate.Email;

                if (!string.IsNullOrEmpty(request.Senha))
                {
                    userUpdate.Senha = BCrypt.Net.BCrypt.HashPassword(request.Senha);
                }

                await repository.UpdateAsync(userUpdate);

                return new Response<Usuario?>
                (userUpdate, message: "Usuário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response<Usuario?>
                (data: null, message: $"Erro ao atualizar usuário: {ex.Message}");
            }
        }
    }
}