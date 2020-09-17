using AutoMapper;
using Domain;

namespace Application.Questionnaires
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Questionnaire, QuestionnaireDto>()
              .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator));
            CreateMap<Question, QuestionDto>();
            CreateMap<Answer, AnswerDto>();
            CreateMap<User, UserDto>();
        }
    }
}
