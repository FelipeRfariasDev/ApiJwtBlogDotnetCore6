using Blog.Application.Interfaces;
using Blog.Infra.Interfaces;

namespace Blog.Application.AppServices
{
    public class ItemAppService : IItemAppService
    {
        IItemRepository _itemRepository;
        public ItemAppService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Insert(string[] linhas, int arquivoId) 
        {
            foreach (var linha in linhas)
            {
                var line = linha.Split(";");
                if (line[0] != "nome")
                {
                    _itemRepository.Insert(arquivoId, line);
                }

            }
        }
    }
}
