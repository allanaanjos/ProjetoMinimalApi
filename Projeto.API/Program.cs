using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.API.Data;
using Projeto.API.handler;
using Projeto.API.Repository;
using Projeto.Domain.Handler;
using Projeto.Domain.IRepository;
using Projeto.Domain.Request.Usuario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioHandler, UsuarioHandler>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICursoHandler, CursoHandler>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapGet("/usuarios", async
([FromServices] IUsuarioHandler handler,
[FromQuery] int pageNumber = 1,
[FromQuery] int pageSize = 10) =>
{
    try
    {
        var request = new GetAllUserRequest{
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
});


app.MapGet("/Usuarios/{id}", async
([FromServices] IUsuarioHandler handler, [FromRoute] int userId) =>
{
    try
    {
        if(userId <= 0 )
          return Results.BadRequest("ID invalido");

        var request = new GetUserByIdRequest { UserId = userId };

        var response = await handler.GetUserById(request);

        if (response.Data == null)
            return Results.NotFound("Usuário não encontrado.");

        return Results.Ok(response.Data);
    }
    catch (Exception ex)
    {
        return Results.Problem($"Erro no servidor: {ex.Message}");
    }
});

app.MapPost("/usuarios/criar", async
 ([FromServices] IUsuarioHandler handler, [FromBody] CreateUserRequest request) =>
{
    try
    {
        if (request == null)
            return Results.BadRequest("Usuário inválido.");

        var response = await handler.CreateUser(request);

        if (response.Data == null)
            return Results.BadRequest
             (response.Message ?? "Erro ao criar o usuário.");

        return Results.Created
         ($"/usuarios/{response.Data.Id}", response.Data);
    }
    catch (Exception ex)
    {
        return Results.Problem
         ($"Erro no servidor: {ex.Message}");
    }
});

app.Run();
