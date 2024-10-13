using System.Security.Cryptography;
using System.Text;

namespace Projeto.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
       public ICollection<UsuarioCurso> UsuarioCursos { get; set; } = new List<UsuarioCurso>();

        public Usuario(string nome, string email, string senha)
        {
            Validacao(nome, email, senha);
            Nome = nome;
            Email = email;
            Senha = HashearSenha(senha);
        }

        public void Validacao(string nome, string email, string senha)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("A senha não pode ser vazia ou nula.");

            if (senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");
        }

        public void UpdateUsuario(string nome, string email, string senha)
        {
            this.Validacao(nome, email, senha);
            Nome = nome;
            Email = email;
            Senha = HashearSenha(senha);
        }

        private string HashearSenha(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(senha);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); 
            }
        }
    }
}
