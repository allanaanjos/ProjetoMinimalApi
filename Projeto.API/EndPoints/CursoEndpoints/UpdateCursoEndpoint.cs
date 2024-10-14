using Projeto.Domain.Handler;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.EndPoints.CursoEndpoints
{
    public class UpdateCursoEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandlerAsync);
        }

        private static async Task<IResult> HandlerAsync
        (int id,
        ICursoHandler handler,
        UpdateCursoRquest request)
        {
            try
            {
                if (id <= 0)
                    return Results.BadRequest("ID inválido.");

                if (request is null)
                    return Results.BadRequest("Requisição de atualização inválida.");

                var getCursoRequest = new GetCursoByIdRequest { CursoId = id };
                var existingCursoResponse = await handler.GetCursoById(getCursoRequest);

                if (existingCursoResponse.Data is null)
                    return Results.NotFound("Curso não encontrado.");

                request.Id = id;
                var updateResponse = await handler.UpdateCurso(request);

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