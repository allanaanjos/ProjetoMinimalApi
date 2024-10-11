using Projeto.Domain.Models;
using Projeto.Domain.Request.Curso;

namespace Projeto.Domain.Handler
{
    public interface ICursoHandler
    {
        Task<Response<Curso?>> CreateCurso(CreateCursoRequest request);
        Task<Response<Curso?>> UpdateCurso(UpdateCursoRquest rquest);
        Task<Response<Curso?>> DeleteCurso(DeleteCursoRequest request);
        Task<Response<Curso?>> GetCursoById(GetCursoByIdRequest request);
        Task<Response<List<Curso>?>> GetAllCursos(GetAllCursosRequest request);
    }
}