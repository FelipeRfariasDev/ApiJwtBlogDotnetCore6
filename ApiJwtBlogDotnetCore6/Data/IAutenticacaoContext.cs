using ApiJwtBlogDotnetCore6.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtBlogDotnetCore6.Data
{
    public interface IAutenticacaoContext
    {
        DbSet<Posts> Posts { get; set; }

        public int SaveChanges();
    }
}
