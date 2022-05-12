using AutoMapper;
using DAL.Entities;
using DTOs;

namespace WebApi.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<PracticalTask, PracticalTaskDto>().ReverseMap();
            CreateMap<QuestionType, QuestionTypeDto>().ReverseMap();
            CreateMap<StudyingMaterials, StudyingMaterialsDto>().ReverseMap();
            CreateMap<Theme, ThemeDto>().ReverseMap();
            CreateMap<UserStatistics, UserStatisticsDto>().ReverseMap();
        }
    }
}