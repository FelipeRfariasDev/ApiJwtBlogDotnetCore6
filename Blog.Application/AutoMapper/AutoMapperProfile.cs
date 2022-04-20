using AutoMapper;
using Blog.Application.ViewModels;
using Blog.Domain.Entities;

namespace Blog.Application.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<PostsViewModel,Posts>();
        }
    }
}
