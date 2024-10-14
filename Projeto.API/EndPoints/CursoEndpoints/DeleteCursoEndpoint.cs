using Projeto.Domain.Handler;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.EndPoints.CursoEndpoints
{
    public class DeleteCursoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (int id, ICursoHandler handler)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("ID inválido.");

                var request = new DeleteCursoRequest { CursoId = id };

                var response = await handler.DeleteCurso(request);

                if (response.Data == null)
                    return Results.NotFound
                    (response.Message ?? "Curso não encontrado.");

                return Results.Ok
                (response.Message ?? "Curso deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return Results.Problem($"Erro no servidor: {ex.Message}");
            }

        }
    }
}