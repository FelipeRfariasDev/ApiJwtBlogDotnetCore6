using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
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
        public PostsController() 
        {
            applicationDbContext = new AutenticacaoContext(new DbContextOptions <AutenticacaoContext>());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<Posts> posts = await applicationDbContext.Posts.Select(x => new Posts { Id = x.Id, Titulo = x.Titulo, Descricao = x.Descricao, DataCadastro = x.DataCadastro }).ToListAsync();
                return Content(JsonConvert.SerializeObject(posts));
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
                
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

        [HttpPost]
        public ActionResult Create([FromBody]Posts posts)
        {
            try
            {
                applicationDbContext.Posts.Add(posts);
                applicationDbContext.SaveChanges();
                return Ok(JsonConvert.SerializeObject(posts));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
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
