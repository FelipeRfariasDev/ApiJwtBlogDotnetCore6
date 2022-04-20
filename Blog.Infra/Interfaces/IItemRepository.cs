namespace Blog.Infra.Interfaces
{
    public interface IItemRepository
    {
        void Insert(int arquivoId, string[] line);
    }
}
