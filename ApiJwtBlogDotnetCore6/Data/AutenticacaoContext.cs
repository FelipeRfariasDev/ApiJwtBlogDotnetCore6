using ApiJwtBlogDotnetCore6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtBlogDotnetCore6.Data
{
    public class AutenticacaoContext: IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Arquivos> Arquivos { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                
                IConfigurationRoot configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .AddJsonFile($"appsettings.{environment}.json", true, true)
                       .AddEnvironmentVariables()
                       .Build();

                
                var connectionString = configuration.GetConnectionString("ConexaoBancoDados");

                optionsBuilder.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //configurar tamanho dos campos da tabela
            builder.Entity<Posts>().Property(p => p.Titulo).HasMaxLength(150).IsRequired();
            builder.Entity<Posts>().Property(p => p.Descricao).IsRequired();
 
            //builder.Entity<Posts>().Ignore(x=>x.Imagem);
            builder.Entity<Arquivos>().Ignore(x=>x.NomeArquivoEnviado);
        }

    }
}
