using ApiCore.Tests.Fixture;
using ApiJwtBlogDotnetCore6.Models;
using ApiJwtBlogDotnetCore6.Repositories;
using System;
using Xunit;

namespace ApiCore.Tests
{
    public class PostTests : IClassFixture<ApiCoreFixture>
    {
        ApiCoreFixture _fixture;

        public PostTests(ApiCoreFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "TesteSoma - RetornandoSucesso")]
        public void TesteSoma()
        {
            Calculadora calculadora = new Calculadora();

            int result = calculadora.Soma(2, 2);

            Assert.Equal(4, result);
        }

        [Fact(DisplayName = "InsertPost - RetornandoSucesso")]
        public void InsertPostTest() 
        {
            var post = GetPostToInsert();
            var repository = new PostRepository(_fixture.AutenticacaoContext);
            var result = repository.Insert(post);
            Assert.True(result);
        }

        private Posts GetPostToInsert()
        {
            return new Posts 
            {
                DataCadastro = DateTime.Now,
                Descricao = "Teste post",
                ImagemUrl = "https://",
                Titulo = "teste"
            };
        }
    }
}