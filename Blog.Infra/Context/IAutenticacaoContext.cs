using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Context
{
    public interface IAutenticacaoContext
    {
        DbSet<Posts> Posts { get; set; }

        public int SaveChanges();
    }
}
