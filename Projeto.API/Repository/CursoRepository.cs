using Microsoft.EntityFrameworkCore;
using Projeto.API.Data;
using Projeto.Domain.IRepository;
using Projeto.Domain.Models;

namespace Projeto.API.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Curso curso)
        {
            var Curso = await _context.Cursos.FindAsync(curso.Id);
            if (Curso != null)
            {
                _context.Cursos.Remove(Curso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Curso>?> GetAllAsync()
         { return await _context.Cursos.AsNoTracking().ToListAsync(); }

        public async Task<Curso?> GetByIdAsync(int id)
         { return await _context.Cursos.FindAsync(id); }

        public async Task UpdateAsync(Curso curso)
        {
            var Curso = await _context.Cursos.FindAsync(curso.Id);
            if (Curso != null)
            {
                _context.Cursos.Update(Curso);
                await _context.SaveChangesAsync();
            }
        }
    }
}