using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projeto.API.Data;
using Projeto.API.EndPoints;
using Projeto.API.handler;
using Projeto.API.Repository;
using Projeto.Domain.Handler;
using Projeto.Domain.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUsuarioHandler, UsuarioHandler>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICursoHandler, CursoHandler>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapEndpoint();

app.Run();
