using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtBlogDotnetCore6.Repositories
{
    public class PostRepository
    {
        AutenticacaoContext _context;
        public PostRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public bool Insert(Posts post) 
        {
            _context.Posts.Add(post);
            int rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }
    }
}
