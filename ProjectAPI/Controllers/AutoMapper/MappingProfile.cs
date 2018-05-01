using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Content, ContentViewModel>();
            CreateMap<Folder, FolderViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}