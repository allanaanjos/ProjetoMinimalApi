using Projeto.Domain.Models;

namespace Projeto.Domain.IRepository
{
    public interface IUserRepository
    {
        Task<Usuario?> GetByIdAsync(int id); 
        Task<List<Usuario>> GetAllAsync(); 
        Task AddAsync(Usuario usuario); 
        Task UpdateAsync(Usuario usuario); 
        Task DeleteAsync(Usuario usuario); 
        
    }
}
