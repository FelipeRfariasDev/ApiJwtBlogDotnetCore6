using Blog.Domain.Entities;
using Blog.Infra.Context;
using Blog.Infra.Interfaces;

namespace Blog.Infra.Repositories
{
    public class ItemRepository : IItemRepository
    {
        AutenticacaoContext _context;
        
        public ItemRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public void Insert(int arquivoId, string[] line)
        {
            _context.Itens.Add(new Itens { ArquivosId = arquivoId, Nome = line[0], Email = line[1] });
            _context.SaveChanges();
        }
    }
}
