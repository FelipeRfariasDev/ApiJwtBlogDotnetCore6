using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Interfaces
{
    public interface IArquivoAppService
    {
        Task<Arquivos> Insert(string filePathDestination, ArquivoViewModel arquivoViewModel);
    }
}
