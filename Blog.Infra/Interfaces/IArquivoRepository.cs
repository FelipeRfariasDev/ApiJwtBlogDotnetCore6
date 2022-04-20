using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Interfaces
{
    public interface IArquivoRepository
    {
        Arquivos Insert(string nomeArquivoEnviadoUrl);
    }
}
