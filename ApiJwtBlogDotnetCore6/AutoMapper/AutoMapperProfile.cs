using ApiJwtBlogDotnetCore6.Models;
using ApiJwtBlogDotnetCore6.ViewModels;
using AutoMapper;

namespace ApiJwtBlogDotnetCore6.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<PostsViewModel,Posts>();
        }
    }
}
