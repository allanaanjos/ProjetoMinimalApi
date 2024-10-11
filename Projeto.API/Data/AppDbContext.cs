using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Models;

namespace Projeto.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<UsuarioCurso> UsuarioCursos { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Tabela de Usuarios
            mb.Entity<Usuario>().HasKey(x => x.Id);
            mb.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(150).IsRequired();
            mb.Entity<Usuario>().Property(x => x.Email).HasMaxLength(200).IsRequired();
            mb.Entity<Usuario>().Property(x => x.Senha).IsRequired();


            // Tabela de Cursos
            mb.Entity<Curso>().HasKey(x => x.Id);
            mb.Entity<Curso>().Property(x => x.Nome).HasMaxLength(150).IsRequired();
            mb.Entity<Curso>().Property(x => x.Descricao).HasMaxLength(500).IsRequired();
            mb.Entity<Curso>().Property(x => x.Preco).IsRequired();
            mb.Entity<Curso>().Property(X => X.DuracaoDoCurso).IsRequired();
            mb.Entity<Curso>().Property(x => x.ImgUrl).IsRequired(false);

            mb.Entity<UsuarioCurso>()
                 .HasKey(uc => new { uc.UsuarioId, uc.CursoId });

            mb.Entity<UsuarioCurso>()
                  .HasOne(x => x.Usuario)
                  .WithMany(x => x.UsuarioCursos)
                  .HasForeignKey(x => x.UsuarioId);

            mb.Entity<UsuarioCurso>()
                  .HasOne(x => x.Curso)
                  .WithMany(x => x.UsuarioCursos)
                  .HasForeignKey(x => x.CursoId);


        }

    }
}