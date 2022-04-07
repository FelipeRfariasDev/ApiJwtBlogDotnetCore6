using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace Blog.Application.ViewModels
{
    public class PostsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        [MaxLength(150, ErrorMessage = "O titulo suporta no máximo 150 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DataCadastroFormatada { get { return DataCadastro.ToString("dd/MM/yyyy"); } }
        public string? ImagemUrl { get; set; }
        public IFormFile Imagem { get; set; }

        public string NovoCampoTeste { get { return Titulo + "-" + Descricao; } }
    }
}
