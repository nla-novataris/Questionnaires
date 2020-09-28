using AutoMapper;
using Domain;
using Application.Dtos;

namespace Application.Questionnaires
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Question, QuestionDto>();

            CreateMap<Answer, AnswerDto>();

            CreateMap<User, UserDto>();

            CreateMap<Questionnaire, QuestionnaireDto>()
              .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator)
              );
          
        }
    }
}
