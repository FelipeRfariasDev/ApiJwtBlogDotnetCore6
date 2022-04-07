using Microsoft.AspNetCore.Http;

namespace Blog.Application.ViewModels
{
    public class ArquivoViewModel
    {
        public int Id { get; set; }
        public string? NomeArquivoEnviadoUrl { get; set; }
        public IFormFile? NomeArquivoEnviado { get; set; }
    }
}
