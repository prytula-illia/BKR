using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace WebApi.Mapper
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<LearnModule, LearnModuleDto>().ReverseMap();
        }
    }
}