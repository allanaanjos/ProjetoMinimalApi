using Projeto.Domain.Handler;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.EndPoints.UsuarioEndpoints
{
    public class UpdateUsuariosEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (int id,
        IUsuarioHandler handler,
        UpdateUserRequest request)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("ID inválido.");

                if (request is null)
                    return Results.BadRequest("Requisição de atualização inválida.");

                var getUserRequest = new GetUserByIdRequest { UserId = id };
                var existingUserResponse = await handler.GetUserById(getUserRequest);

                if (existingUserResponse.Data is null)
                    return Results.NotFound("Usuário não encontrado.");

                request.Id = id;
                var updateResponse = await handler.UpdateUser(request);

                if (updateResponse.Data is null)
                    return Results.BadRequest(updateResponse.Message);

                return Results.Ok(updateResponse.Data);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro no servidor: {ex.Message}");
            }

        }
    }
}