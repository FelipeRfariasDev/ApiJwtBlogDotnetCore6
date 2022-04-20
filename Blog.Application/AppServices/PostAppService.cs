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

        public bool Delete(int id)
        {
            var posts = GetById(id);
            if (posts == null)
                throw new Exception("post id " + id + " não encontrado");

            return _postRepository.Delete(posts);
        }

        public Posts GetById(int id)
        {
            return _postRepository.GetById(id);
        }
    }
}
