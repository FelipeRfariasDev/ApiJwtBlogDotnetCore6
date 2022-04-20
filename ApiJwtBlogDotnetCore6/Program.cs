using ApiJwtBlogDotnetCore6.Configuration;
using Blog.Application.AppServices;
using Blog.Application.Interfaces;
using Blog.Infra.Context;
using Blog.Infra.Interfaces;
using Blog.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("ConexaoBancoDados");
builder.Services.AddDbContext<AutenticacaoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddScoped<IPostAppService, PostAppService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IArquivoAppService, ArquivoAppService>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
builder.Services.AddScoped<IItemAppService, ItemAppService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
