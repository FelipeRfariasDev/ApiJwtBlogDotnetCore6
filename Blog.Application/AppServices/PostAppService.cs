using Blog.Application.Interfaces;
using Blog.Domain.Entities;
using Blog.Infra.Interfaces;

namespace Blog.Application.AppServices
{
    public class PostAppService : IPostAppService
    {
        IPostRepository _postRepository;
        public PostAppService(IPostRepository postRepository)
        {
                _postRepository = postRepository;
        }

        public Posts GetById(int id)
        {
            return _postRepository.GetById(id);
        }
    }
}
