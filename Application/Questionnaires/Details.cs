using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Questionnaires
{
    public class Details
    {
        public class Query : IRequest<QuestionnaireDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, QuestionnaireDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)

            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<QuestionnaireDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionnaire = await _context.Questionnaires
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers)
                    .Include(x => x.Creator)
                    .SingleOrDefaultAsync(x => x.Id == request.Id);

                if (questionnaire == null)
                {
                    throw new Exception("Could not find questionnaire");
                }

                var questionnaireToReturn = _mapper.Map<Questionnaire, QuestionnaireDto>(questionnaire);

                return questionnaireToReturn;
            }
        }
    }
}