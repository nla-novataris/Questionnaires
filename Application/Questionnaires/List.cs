using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Dtos;

namespace Application.Questionnaires
{
    public class List
    {
        public class Query : IRequest<List<QuestionnaireDto>> { }
        public class Handler : IRequestHandler<Query, List<QuestionnaireDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<QuestionnaireDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionnaires = await _context.Questionnaires.ToListAsync();

                var questionnaireToReturn = _mapper.Map<List<Questionnaire>, List<QuestionnaireDto>>(questionnaires);

                return questionnaireToReturn;
            }
        }
    }
}