using ApiJwtBlogDotnetCore6.Data;
using ApiJwtBlogDotnetCore6.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtBlogDotnetCore6.Repositories
{
    public class PostRepository
    {
        IAutenticacaoContext _context;
        public PostRepository(IAutenticacaoContext context)
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
