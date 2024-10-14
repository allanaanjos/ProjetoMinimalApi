using Projeto.Domain.Handler;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.EndPoints.CursoEndpoints
{
    public class GetByIdCursoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapGet("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (int id, ICursoHandler handler)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("Id invalido");

                var request = new GetCursoByIdRequest { CursoId = id };

                var response = await handler.GetCursoById(request);

                if (response.Data == null)
                    return Results.NotFound("Usuário não encontrado.");

                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro de servidor: {ex.Message}");
            }
        }
    }
}