using Projeto.Domain.Handler;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.EndPoints.UsuarioEndpoints
{
    public class DeleteUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
             app.MapDelete("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (int id, IUsuarioHandler handler)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("ID inválido.");

                var request = new DeleteUserRequest { UserId = id };

                var response = await handler.DeleteUser(request);

                if (response.Data == null)
                    return Results.NotFound
                    (response.Message ?? "Usuário não encontrado.");

                return Results.Ok
                (response.Message ?? "Usuário deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro no servidor: {ex.Message}");
            }
        }
    }
}