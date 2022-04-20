using Blog.Application.ViewModels;
using Blog.Domain.Entities;

namespace Blog.Application.Interfaces
{
    public interface IPostAppService
    {
        Posts GetById(int id);

        bool Delete(int id);
        Task<Posts> Insert(PostsViewModel postsViewModel, string uploads, string host);
    }
}
