using Projeto.Domain.Handler;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.EndPoints.CursoEndpoints
{
    public class CreateCursoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
           app.MapPost("/criar", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync(
        ICursoHandler handler, CreateCursoRequest request)
        {
            try
            {
                if (request == null)
                    return Results.BadRequest("Curso inválido.");

                var response = await handler.CreateCurso(request);

                if (response.Data == null)
                    return Results.BadRequest
                     (response.Message ?? "Erro ao criar o Curso.");

                return Results.Created
                 ($"/cursos/{response.Data.Id}", response.Data);
            }
            catch (Exception ex)
            {
                return Results.Problem
                 ($"Erro no servidor: {ex.Message}");
            }
        }
    }
}