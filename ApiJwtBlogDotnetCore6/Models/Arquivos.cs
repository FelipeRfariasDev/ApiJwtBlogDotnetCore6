namespace ApiJwtBlogDotnetCore6.Models
{
    public class Arquivos
    {
        public int Id { get; set; }
        public string? NomeArquivoEnviadoUrl { get; set; }
        public IFormFile? NomeArquivoEnviado { get; set; }
    }
}
