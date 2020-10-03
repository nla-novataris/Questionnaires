using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using Application.Dtos;

namespace Application.Questionnaires
{
    public class Details
    {
        public class Query : IRequest<QuestionnaireDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, QuestionnaireDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QuestionnaireDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionnaire = await _context.Questionnaires
                    .FindAsync(request.Id);

                var questionnaireToReturn = _mapper.Map<Questionnaire, QuestionnaireDto>(questionnaire);

                if (questionnaire == null)
                {
                    throw new Exception("Could not find questionnaire");
                }

                return questionnaireToReturn;
            }
        }
    }
}