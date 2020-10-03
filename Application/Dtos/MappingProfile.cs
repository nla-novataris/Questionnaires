using AutoMapper;
using Domain;

namespace Application.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();

            CreateMap<Answer, AnswerDto>();

            CreateMap<UserAnswer, UserAnswerDto>();

            CreateMap<User, UserDto>();

            CreateMap<Questionnaire, QuestionnaireDto>()
              .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator)
              );
        }
    }
}
