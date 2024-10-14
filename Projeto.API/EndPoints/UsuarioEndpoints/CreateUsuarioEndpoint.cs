using Projeto.Domain.Handler;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.EndPoints.UsuarioEndpoints
{
    public class CreateUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPost("/criar", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (IUsuarioHandler handler, CreateUserRequest request)
        {
            try
            {
                if (request == null)
                    return Results.BadRequest("Usuário inválido.");

                var response = await handler.CreateUser(request);

                if (response.Data == null)
                    return Results.BadRequest(response.Message ?? "Erro ao criar o usuário.");

                return Results.Created($"/usuarios/{response.Data.Id}", response.Data);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error de servidor{ex.Message}");
            }
        }
    }
}
