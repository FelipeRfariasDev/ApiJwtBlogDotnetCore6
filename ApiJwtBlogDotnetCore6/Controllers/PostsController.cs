using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;

namespace ApiJwtBlogDotnetCore6.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        AutenticacaoContext applicationDbContext;
        IWebHostEnvironment _hostingEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        public PostsController(IWebHostEnvironment hostEnvironment, IHttpContextAccessor iHttpContextAccessor) 
        {
            applicationDbContext = new AutenticacaoContext(new DbContextOptions <AutenticacaoContext>());
            this._hostingEnvironment = hostEnvironment;
            this._httpContextAccessor = iHttpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //var query = from p in applicationDbContext.Posts select new  {p.Id, p.Titulo, p.Descricao, p.DataCadastroFormatada};
            //var query = from p in applicationDbContext.Posts where p.Id == 8 select p;
            //var query = from p in applicationDbContext.Posts select p;

            /*
            var query = from p in applicationDbContext.Posts join 
                        c in applicationDbContext.Comentarios on p.Id equals c.postid
                        where p.Id == 8 select new { p.Id, p.Titulo, p.Descricao, p.DataCadastroFormatada, c.Id,c.Titulo,c.Descricao };
            */
            var query = applicationDbContext.Posts.FromSqlRaw("select * from posts").ToList();

            return Content(JsonConvert.SerializeObject(query));
            /*
            try
            {
                List<Posts> posts = await applicationDbContext.Posts.Select(x => new Posts { Id = x.Id, Titulo = x.Titulo, Descricao = x.Descricao, DataCadastro = x.DataCadastro }).ToListAsync();
                return Content(JsonConvert.SerializeObject(posts));
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }*/


        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult> Details([FromRoute]int id)
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

        /*
        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> files)
        {
            string uploads = Path.Combine(this._hostingEnvironment.ContentRootPath, "uploadsImgs");
            foreach (IFormFile file in files)
            {
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }*/

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]Posts posts)
        {
            try
            {
                string uploads = Path.Combine(this._hostingEnvironment.WebRootPath, "uploadsImgs");
                if (posts.Imagem.Length > 0)
                {
                    string filePath = Path.Combine(uploads, posts.Imagem.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await posts.Imagem.CopyToAsync(fileStream);
                    }
                    string host = this._httpContextAccessor.HttpContext.Request.Host.Value;

                    posts.ImagemUrl = host + "/uploadsImgs/" + posts.Imagem.FileName;
                }
                
                applicationDbContext.Posts.Add(posts);
                applicationDbContext.SaveChanges();

                var retorno = new {
                    success = true,
                    message = "cadastrado com sucesso",
                    post = posts
                };

                return Ok(JsonConvert.SerializeObject(retorno));

                

            }
            catch(Exception ex)
            {
                var retorno = new
                {
                    success = false,
                    message = ex
                };

                return BadRequest(retorno);
            }
        }

        [HttpPut]
        public ActionResult Edit([FromBody]Posts posts)
        {
            try
            {
                applicationDbContext.Posts.Update(posts);
                applicationDbContext.SaveChanges();
                return Ok(JsonConvert.SerializeObject(posts));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete([FromRoute]int Id)
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
                return Ok("post id "+ Id + "removido com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
