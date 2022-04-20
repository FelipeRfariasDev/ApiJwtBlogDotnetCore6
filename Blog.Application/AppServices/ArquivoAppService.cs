using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;
using Blog.Infra.Interfaces;

namespace Blog.Application.AppServices
{
    public class ArquivoAppService : IArquivoAppService
    {
        IArquivoRepository _arquivoRepository;
        IItemAppService _itemAppService;
        public ArquivoAppService(IArquivoRepository arquivoRepository, IItemAppService itemAppService)
        {
            this._arquivoRepository = arquivoRepository;
            this._itemAppService = itemAppService;
        }

        public async Task<Arquivos> Insert(string filePathDestination, ArquivoViewModel arquivoViewModel)
        {
            
            string filePath = "";

            if (arquivoViewModel.NomeArquivoEnviado != null && arquivoViewModel.NomeArquivoEnviado.Length > 0)
            {
                filePath = Path.Combine(filePathDestination, arquivoViewModel.NomeArquivoEnviado.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await arquivoViewModel.NomeArquivoEnviado.CopyToAsync(fileStream);
                }
            }

            var nomeArquivoEnviadoUrl = "uploadsCsv/" + arquivoViewModel.NomeArquivoEnviado.FileName;

            var arquivo = this._arquivoRepository.Insert(nomeArquivoEnviadoUrl);

            var fileText = System.IO.File.ReadAllText(filePath);
            var linhas = fileText.Split("\r\n");

            this._itemAppService.Insert(linhas, arquivo.Id);

            return arquivo;
        }
    }
}
