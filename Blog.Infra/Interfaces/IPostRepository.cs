using Blog.Domain.Entities;

namespace Blog.Infra.Interfaces
{
    public interface IPostRepository
    {
        Posts GetById(int id);
        bool Delete(Posts posts);
        Posts Insert(Posts post);
    }
}
