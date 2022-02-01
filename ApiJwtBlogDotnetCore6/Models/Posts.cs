using System.ComponentModel.DataAnnotations;

namespace ApiJwtBlogDotnetCore6.Models
{
    public class Posts
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo Titulo é obrigatório")]
        //[MaxLength(5,ErrorMessage = "O titulo suporta no máximo 5 caracteres")]
        public string Titulo { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataCadastroFormatada { get { return DataCadastro.ToString("dd/MM/yyyy"); } }
        public string ImagemUrl { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
