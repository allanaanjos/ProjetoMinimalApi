using System.ComponentModel.DataAnnotations;

namespace Projeto.Domain.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public TimeSpan DuracaoDoCurso { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public ICollection<UsuarioCurso> UsuarioCursos {get; set;} = new List<UsuarioCurso>();

       
        public Curso(int id, string nome, string descricao, double preco, TimeSpan time, string img = "")
        {
            Validation(id, nome, descricao, preco, time, img);
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DuracaoDoCurso = time;
            ImgUrl = img;
        }

        
        public void Validation(int id, string nome, string descricao, double preco, TimeSpan time, string img = "")
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que 0.");

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição não pode ser vazia ou nula.");

            if (preco <= 0)
                throw new ArgumentException("O preço deve ser maior que 0.");

            if (time <= TimeSpan.Zero)
                throw new ArgumentException("A duração do curso deve ser positiva.");

            if (!string.IsNullOrEmpty(img) && !Uri.IsWellFormedUriString(img, UriKind.Absolute))
                throw new ArgumentException("A URL da imagem não é válida.");
        }

        public void UpdateCurso(int id, string nome, string descricao, double preco, TimeSpan time, string img = "")
        {
            Validation(id, nome, descricao, preco, time, img);
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DuracaoDoCurso = time;
            ImgUrl = img;
        }
    }
}
