using Projeto.Domain.Models;

namespace Projeto.Domain.IRepository
{
    public interface ICursoRepository
    {
        Task<Curso?> GetByIdAsync(int id);
        Task<List<Curso>?> GetAllAsync();
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(Curso curso);
    }
}