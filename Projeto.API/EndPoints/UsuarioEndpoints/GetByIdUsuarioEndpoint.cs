using Projeto.Domain.Handler;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.EndPoints.UsuarioEndpoints
{
    public class GetByIdUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (IUsuarioHandler handler, int id)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("ID invalido");

                var request = new GetUserByIdRequest { UserId = id };

                var response = await handler.GetUserById(request);

                if (response.Data == null)
                    return Results.NotFound("Usuário não encontrado.");

                return Results.Ok(response.Data);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro no servidor: {ex.Message}");
            }
        }
    }
}