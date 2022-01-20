using ApiJwtBlogDotnetCore6.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiJwtBlogDotnetCore6.Data
{
    public class AutenticacaoContext: IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
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

    }
}
