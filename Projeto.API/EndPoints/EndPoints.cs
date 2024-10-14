using Projeto.API.EndPoints.CursoEndpoints;
using Projeto.API.EndPoints.UsuarioEndpoints;

namespace Projeto.API.EndPoints
{
    public static class EndPoints
    {
        public static void MapEndpoint(this WebApplication app)
        {
            var endPoints = app.MapGroup("");

            endPoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

            endPoints.MapGroup("/v1/usuarios")
            .WithTags("Usuario")
            .MapEndpoint<CreateUsuarioEndpoint>()
            .MapEndpoint<UpdateUsuariosEndpoint>()
            .MapEndpoint<GetAllUsuarioEndpoint>()
            .MapEndpoint<GetByIdUsuarioEndpoint>()
            .MapEndpoint<DeleteUsuarioEndpoint>();

            endPoints.MapGroup("/v1/cursos")
            .WithTags("Curso")
            .MapEndpoint<CreateCursoEndpoint>()
            .MapEndpoint<UpdateCursoEndpoint>()
            .MapEndpoint<GetAllCursosEndpoint>()
            .MapEndpoint<GetByIdCursoEndpoint>()
            .MapEndpoint<DeleteCursoEndpoint>();
        }
        private static IEndpointRouteBuilder MapEndpoint
        <TEndpoint>(this IEndpointRouteBuilder app)
         where TEndpoint : IEndpoint
        {
            TEndpoint.Map(app);
            return app;
        }
    }
}
