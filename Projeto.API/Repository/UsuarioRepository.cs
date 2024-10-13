using Microsoft.EntityFrameworkCore;
using Projeto.API.Data;
using Projeto.Domain.IRepository;
using Projeto.Domain.Models;

namespace Projeto.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Usuario usuario)
        {
            var user = await _context.Usuarios.FindAsync(usuario.Id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>?> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario); 
            await _context.SaveChangesAsync(); 
        }
    }
}
