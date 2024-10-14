using Projeto.Domain.Handler;
using Projeto.Domain.IRepository;
using Projeto.Domain.Models;
using Projeto.Domain.Request.Curso;

namespace Projeto.API.handler
{
    public class CursoHandler : ICursoHandler
    {
        private readonly ICursoRepository repository;

        public CursoHandler(ICursoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response<Curso?>> CreateCurso(CreateCursoRequest request)
        {
            try
            {
                var data = new Curso(
                    nome: request.Nome,
                    descricao: request.Descricao,
                    preco: request.Preco,
                    duracaoDoCurso: request.DuracaoDoCurso,
                    imgUrl: request.ImgUrl ?? string.Empty
                );


                await repository.AddAsync(data);


                return new Response<Curso?>(data, message: "Curso criado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Curso?>
                 (data: null, message: $"Não foi possível criar o curso: {ex.Message}");
            }
        }

        public async Task<Response<Curso?>> DeleteCurso(DeleteCursoRequest request)
        {
            try
            {
                var curso = await repository.GetByIdAsync(request.CursoId);

                if (curso is null)
                    return new Response<Curso?>
                     (data: null, message: "Curso não foi encontrado.");

                await repository.DeleteAsync(curso);

                return new Response<Curso?>(curso, message: "Curso foi removido!");
            }
            catch (Exception ex)
            {
                return new Response<Curso?>
                (data: null, message: $"Não foi possivel remover o curso: {ex}");
            }
        }

        public async Task<Response<List<Curso>?>> GetAllCursos(GetAllCursosRequest request)
        {
            try
            {
                var data = await repository.GetAllAsync();

                if (data == null || !data.Any())
                {
                    return new Response<List<Curso>?>
                     (data: null, message: "Cursos não encontrados.");
                }

                return new Response<List<Curso>?>(data);
            }
            catch (Exception ex)
            {
                return new Response<List<Curso>?>
                 (data: null, message: $"Erro no servidor: {ex.Message}");
            }
        }

        public async Task<Response<Curso?>> GetCursoById(GetCursoByIdRequest request)
        {
            try
            {
                var curso = await repository.GetByIdAsync(request.CursoId);

                if (curso is null)
                    return new Response<Curso?>
                     (data: null, message: "Curso não encontrado.");

                return new Response<Curso?>(curso);
            }
            catch (Exception ex)
            {
                return new Response<Curso?>
                 (data: null, message: $"Erro de servidor: {ex.Message}");
            }

        }

        public async Task<Response<Curso?>> UpdateCurso(UpdateCursoRquest request)
        {
            try
            {
                var curso = await repository.GetByIdAsync(request.Id);

                if (curso is null)
                    return new Response<Curso?>
                     (data: null, message: "Curso não encontrado.");

                curso.Nome = request.Nome;
                curso.Descricao = request.Descricao;
                curso.Preco = request.Preco;
                curso.DuracaoDoCurso = request.DuracaoDoCurso;
                curso.ImgUrl = request.ImgUrl ?? curso.ImgUrl;

                await repository.UpdateAsync(curso);

                return new Response<Curso?>
                 (curso, message: "Curso atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new Response<Curso?>
                 (data: null, message: $"Erro de servidor: {ex.Message}");
            }
        }
    }
}