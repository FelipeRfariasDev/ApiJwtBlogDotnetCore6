namespace Blog.Domain.Entities
{
    public class Itens
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int ArquivosId { get; set; }
        public Arquivos Arquivo { get; set; }
    }
}
