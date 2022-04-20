using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Blog.Infra.Interfaces;

namespace Blog.Application.AppServices
{
    public class PostAppService : IPostAppService
    {
        IPostRepository _postRepository;
        IMapper _mapper;
        public PostAppService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
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

        public async Task<Posts> Insert(PostsViewModel postsViewModel, string uploads, string host)
        {
            if (postsViewModel.Imagem.Length > 0)
            {
                string uploadsImgs = "uploadsImgs";
                string filePath = Path.Combine(uploads, postsViewModel.Imagem.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await postsViewModel.Imagem.CopyToAsync(fileStream);
                }


                string ImgUrl = "https://" + host + "/" + uploadsImgs + "/";
                postsViewModel.ImagemUrl = ImgUrl + postsViewModel.Imagem.FileName;
            }
            DateTime DataCadastro = DateTime.Now;
            postsViewModel.DataCadastro = DataCadastro;
            /* Exemplo sem utilizar o mapper
            var post = new Posts { Titulo = postsViewModel.Titulo, Descricao = postsViewModel.Descricao, DataCadastro = postsViewModel.DataCadastro, ImagemUrl = postsViewModel.ImagemUrl };
            */

            //Exemplo com o mapper
            var post = this._mapper.Map<Posts>(postsViewModel);
            post = _postRepository.Insert(post);
            return post;
        }
    }
}
