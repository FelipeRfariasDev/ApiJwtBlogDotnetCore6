using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiJwtBlogDotnetCore6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArquivosController : Controller
    {
        IWebHostEnvironment _hostingEnvironment;
        IArquivoAppService _arquivoAppService;
        public ArquivosController(IWebHostEnvironment hostEnvironment, IArquivoAppService arquivoAppService)
        {
            this._hostingEnvironment = hostEnvironment;
            this._arquivoAppService = arquivoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ArquivoViewModel arquivos)
        {
            try
            {
                string diretorioUploadsCsv = "uploadsCsv";
                string filePathDestination = Path.Combine(this._hostingEnvironment.WebRootPath, diretorioUploadsCsv);
                var arquivo = await _arquivoAppService.Insert(filePathDestination, arquivos);
                var retorno = FillResponseObject(true, "Cadastrado com sucesso", arquivo);
                return Ok(JsonConvert.SerializeObject(retorno));
            }
            catch (Exception ex)
            {
                var retorno = FillResponseObject(false, ex.Message);
                return Ok(JsonConvert.SerializeObject(retorno));
            }
        }

        private object FillResponseObject(bool success, string message, Arquivos arquivos = null)
        {
            return new
            {
                success = success,
                message = message,
                arquivo = arquivos
            };
        }
    }
}
