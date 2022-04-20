using Blog.Domain.Entities;
using Blog.Infra.Context;
using Blog.Infra.Interfaces;

namespace Blog.Infra.Repositories
{
    public class PostRepository : IPostRepository
    {
        AutenticacaoContext _context;
        public PostRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public bool Delete(Posts posts)
        {
            _context.Remove(posts);
            int rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }

        public Posts GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        public Posts Insert(Posts post)
        {
            //post.Id = 0;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }
    }
}
