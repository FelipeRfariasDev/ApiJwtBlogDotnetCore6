using Blog.Domain.Entities;
using Blog.Infra.Context;
using Blog.Infra.Interfaces;

namespace Blog.Infra.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        AutenticacaoContext _context;
        public ArquivoRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public Arquivos Insert(string nomeArquivoEnviadoUrl) 
        {
            var arquivo = new Arquivos { NomeArquivoEnviadoUrl = nomeArquivoEnviadoUrl };
            _context.Arquivos.Add(arquivo);
            _context.SaveChanges();
            return arquivo;
        }
    }
}
