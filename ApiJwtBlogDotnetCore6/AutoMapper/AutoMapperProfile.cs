using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;

namespace ApiJwtBlogDotnetCore6.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<PostsViewModel,Posts>();
        }
    }
}
