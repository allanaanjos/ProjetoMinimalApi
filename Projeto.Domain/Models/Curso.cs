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

       
        public Curso( string nome, string descricao, double preco, TimeSpan duracaoDoCurso , string imgUrl = "")
        {
            Validation(nome, descricao, preco, duracaoDoCurso , imgUrl);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DuracaoDoCurso = duracaoDoCurso ;
            ImgUrl = imgUrl;
        }

        
        public void Validation(string nome, string descricao, double preco, TimeSpan duracaoDoCurso , string imgUrl = "")
        {

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição não pode ser vazia ou nula.");

            if (preco <= 0)
                throw new ArgumentException("O preço deve ser maior que 0.");

            if (duracaoDoCurso  <= TimeSpan.Zero)
                throw new ArgumentException("A duração do curso deve ser positiva.");

            if (!string.IsNullOrEmpty(imgUrl) && !Uri.IsWellFormedUriString(imgUrl, UriKind.Absolute))
                throw new ArgumentException("A URL da imagem não é válida.");
        }

        public void UpdateCurso(string nome, string descricao, double preco, TimeSpan duracaoDoCurso , string imgUrl = "")
        {
            Validation(nome, descricao, preco, duracaoDoCurso , imgUrl);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            DuracaoDoCurso = duracaoDoCurso;
            ImgUrl = imgUrl;
        }
    }
}
