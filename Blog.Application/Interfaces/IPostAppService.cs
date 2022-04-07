using Blog.Domain.Entities;

namespace Blog.Application.Interfaces
{
    public interface IPostAppService
    {
        Posts GetById(int id);
    }
}
