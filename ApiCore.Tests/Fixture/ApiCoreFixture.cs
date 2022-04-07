using Blog.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCore.Tests.Fixture
{
    public class ApiCoreFixture
    {
        public AutenticacaoContext AutenticacaoContext { get; set; }

        public ApiCoreFixture()
        {
            ConfigureContext();
        }

        public void ConfigureContext() 
        {
            var options = new DbContextOptionsBuilder<AutenticacaoContext>()
                .UseInMemoryDatabase("blog")
                .Options;

            AutenticacaoContext = new AutenticacaoContext(options);
        }
    }
}
