using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
using ApiJwtBlogDotnetCore6.Services;
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
    public class PostsController : Controller
    {
        AutenticacaoContext applicationDbContext;
        IWebHostEnvironment _hostingEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        IMapper _mapper;
        public PostsController(IWebHostEnvironment hostEnvironment, IHttpContextAccessor iHttpContextAccessor, IMapper mapper)
        {
            applicationDbContext = new AutenticacaoContext(new DbContextOptions<AutenticacaoContext>());
            this._hostingEnvironment = hostEnvironment;
            this._httpContextAccessor = iHttpContextAccessor;
            this._mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(int? offset = 0, int? limit = 10, string? buscar = null)
        {

            //var query = from p in applicationDbContext.Posts select new  {p.Id, p.Titulo, p.Descricao, p.DataCadastroFormatada};
            //var query = from p in applicationDbContext.Posts where p.Id == 8 select p;
            //var query = from p in applicationDbContext.Posts select p;

            /*
            var query = from p in applicationDbContext.Posts join 
                        c in applicationDbContext.Comentarios on p.Id equals c.postid
                        where p.Id == 8 select new { p.Id, p.Titulo, p.Descricao, p.DataCadastroFormatada, c.Id,c.Titulo,c.Descricao };
            */
            //var query = applicationDbContext.Posts.FromSqlRaw("select * from posts").ToList();

            //return Content(JsonConvert.SerializeObject(query));

            try
            {
                //List<PostsViewModel> posts = await applicationDbContext.Posts.Select(x => new PostsViewModel { Id = x.Id, Titulo = x.Titulo, Descricao = x.Descricao, DataCadastro = x.DataCadastro }).ToListAsync();
                var listaPosts = await applicationDbContext.Posts
                    .Where(x => x.Titulo.Contains(buscar != null ? buscar : x.Titulo)
                    || x.Descricao.Contains(buscar != null ? buscar : x.Descricao))
                    .Skip((int)offset * (int)limit)
                        .Take((int)limit)
                        .ToListAsync();

                return Content(JsonConvert.SerializeObject(listaPosts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details([FromRoute] int id)
        {
            try
            {
                var post = await applicationDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
                return Content(JsonConvert.SerializeObject(post));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PostsViewModel postsViewModel)
        {
            try
            {
                string uploadsImgs = "uploadsImgs";
                string uploads = Path.Combine(this._hostingEnvironment.WebRootPath, uploadsImgs);
                if (postsViewModel.Imagem.Length > 0)
                {
                    string filePath = Path.Combine(uploads, postsViewModel.Imagem.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postsViewModel.Imagem.CopyToAsync(fileStream);
                    }
                    string host = this._httpContextAccessor.HttpContext.Request.Host.Value;

                    postsViewModel.ImagemUrl = "https://" + host + "/" + uploadsImgs + "/" + postsViewModel.Imagem.FileName;
                }
                DateTime DataCadastro = DateTime.Now;
                postsViewModel.DataCadastro = DataCadastro;
                /* Exemplo sem utilizar o mapper
                var post = new Posts { Titulo = postsViewModel.Titulo, Descricao = postsViewModel.Descricao, DataCadastro = postsViewModel.DataCadastro, ImagemUrl = postsViewModel.ImagemUrl };
                */

                //Exemplo com o mapper
                var post = this._mapper.Map<Posts>(postsViewModel);

                applicationDbContext.Posts.Add(post);
                applicationDbContext.SaveChanges();

                var emailServices = new EmailServices();

                var body = emailServices.GetEmailBody();
                var email = new Email();
                email.To = new List<EmailAddress>();
                email.To.Add(new EmailAddress { Address = "felipe.farias.php@gmail.com", Name = "Felipe" });
                emailServices.SendEmail(email, "Blog API", body);

                var retorno = new
                {
                    success = true,
                    message = "cadastrado com sucesso",
                    post = post
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

        [HttpPut]
        public ActionResult Edit([FromBody] Posts posts)
        {
            try
            {
                applicationDbContext.Posts.Update(posts);
                applicationDbContext.SaveChanges();
                return Ok(JsonConvert.SerializeObject(posts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var posts = applicationDbContext.Posts.Find(Id);
                if (posts == null)
                {
                    return BadRequest("post id " + Id + " não encontrado");
                }
                applicationDbContext.Posts.Remove(posts);
                applicationDbContext.SaveChanges();
                return Ok("post id " + Id + "removido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
