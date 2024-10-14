using Projeto.Domain.Handler;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.EndPoints.CursoEndpoints
{
    public class GetAllCursosEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (ICursoHandler handler,
         int pageSize = 10,
         int pageNumber = 1)
        {
            try
            {
                var request = new GetAllCursosRequest
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                var response = await handler.GetAllCursos(request);

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro no servidor: {ex.Message}");
            }
        }
    }
}