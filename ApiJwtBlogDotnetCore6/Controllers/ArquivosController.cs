using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
using ApiJwtBlogDotnetCore6.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ApiJwtBlogDotnetCore6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArquivosController : Controller
    {
        AutenticacaoContext applicationDbContext;
        IWebHostEnvironment _hostingEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;
        public ArquivosController(IWebHostEnvironment hostEnvironment, IHttpContextAccessor iHttpContextAccessor, IMapper mapper)
        {
            applicationDbContext = new AutenticacaoContext(new DbContextOptions<AutenticacaoContext>());
            this._hostingEnvironment = hostEnvironment;
            this._httpContextAccessor = iHttpContextAccessor;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Arquivos arquivos)
        {
            try
            {
                string uploadsImgs = "uploadsCsv";
                string uploads = Path.Combine(this._hostingEnvironment.WebRootPath, uploadsImgs);
                string filePath = "";

                if (arquivos.NomeArquivoEnviado!=null && arquivos.NomeArquivoEnviado.Length > 0)
                {
                    filePath = Path.Combine(uploads, arquivos.NomeArquivoEnviado.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await arquivos.NomeArquivoEnviado.CopyToAsync(fileStream);
                    }
                }

                var NomeArquivoEnviadoUrl = uploadsImgs + "/" + arquivos.NomeArquivoEnviado.FileName;

                var arquivo = new Arquivos { NomeArquivoEnviadoUrl = NomeArquivoEnviadoUrl };
                
                applicationDbContext.Arquivos.Add(arquivo);
                applicationDbContext.SaveChanges();

                var fileText = System.IO.File.ReadAllText(filePath);

                var linhas = fileText.Split("\r\n");

                foreach (var linha in linhas) { 
                    var line = linha.Split(";");
                    if (line[0] != "nome")
                    {
                        applicationDbContext.Itens.Add(new Itens { ArquivosId = arquivo.Id, Nome = line[0], Email = line[1] });
                    }
                    
                }
                applicationDbContext.SaveChanges();

                var retorno = new
                {
                    success = true,
                    message = "cadastrado com sucesso",
                    arquivo = arquivo
                };
                
                return Ok(JsonConvert.SerializeObject(retorno));
            }
            catch (Exception ex)
            {
                var retorno = new
                {
                    success = false,
                    message = ex
                };

                return Ok(JsonConvert.SerializeObject(retorno));
            }
        }
    }
}
