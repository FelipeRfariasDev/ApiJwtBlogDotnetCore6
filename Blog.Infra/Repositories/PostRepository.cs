using Blog.Domain.Entities;
using Blog.Infra.Context;
using Blog.Infra.Interfaces;

namespace Blog.Infra.Repositories
{
    public class PostRepository: IPostRepository
    {
        AutenticacaoContext _context;
        public PostRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public Posts GetById(int id)
        {
            return _context.Posts.Find(id);
        }

        public bool Insert(Posts post) 
        {
            _context.Posts.Add(post);
            int rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }
    }
}
