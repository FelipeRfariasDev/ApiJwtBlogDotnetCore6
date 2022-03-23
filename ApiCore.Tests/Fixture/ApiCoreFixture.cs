using ApiJwtBlogDotnetCore6.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
