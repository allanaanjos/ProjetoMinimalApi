
using Projeto.Domain.Handler;
using Projeto.Domain.Request.Usuario;

namespace Projeto.API.EndPoints.UsuarioEndpoints
{
    public class GetAllUsuarioEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandlerAsync);
        }


        private static async Task<IResult> HandlerAsync
        (IUsuarioHandler handler,
        int pageNumber = 1,
        int pageSize = 10)
        {

            try
            {
                var request = new GetAllUserRequest
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var response = await handler.GetAllUser(request);

                if (response.Data is null || !response.Data.Any())
                {
                    return Results.NotFound
                      (new { message = "Usuários não encontrados" });
                }

                return Results.Ok(response.Data);
            }
            catch (Exception ex)
            {
                return Results.Problem
                  ($"Erro no servidor: {ex.Message}");
            }

        }
    }
}