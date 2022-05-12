using AutoMapper;
using DAL.Entities;
using DTOs;

namespace WebApi.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<StudyingMaterials, StudyingMaterialsDto>().ReverseMap();
        }
    }
}