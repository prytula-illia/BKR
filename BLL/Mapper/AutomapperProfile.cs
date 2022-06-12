using AutoMapper;
using DAL.Authentication;
using DAL.Entities;
using DTOs;
using DTOs.Authentication;

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
            CreateMap<Theme, ThemeDto>()
                .ForMember(x => x.CourseId, opt => opt.MapFrom(c => c.Course.Id));
            CreateMap<ThemeDto, Theme>();
            CreateMap<ThemeRating, ThemeRatingDto>()
                .ForMember(x => x.ThemeId, opt => opt.MapFrom(c => c.Theme.Id));
            CreateMap<ThemeRatingDto, ThemeRating>();
            CreateMap<CommentRating, CommentRatingsDto>()
                .ForMember(x => x.CommentId, opt => opt.MapFrom(c => c.Comment.Id));
            CreateMap<CommentRatingsDto, CommentRating>();
            CreateMap<UserStatistics, UserStatisticsDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<LoginModel, LoginModelDto>().ReverseMap();
            CreateMap<RegisterModel, RegisterModelDto>().ReverseMap();
        }
    }
}