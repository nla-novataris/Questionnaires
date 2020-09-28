using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using Application.Dtos;
using AutoMapper;

namespace Application.Questions
{
    public class Details
    {
        public class Query : IRequest<QuestionDto>
        {
            public Guid Id { get; set; }
                
        }

        public class Handler : IRequestHandler<Query, QuestionDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)

            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<QuestionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var question = await _context.Questions.FindAsync(request.Id);

                if (question == null)
                {
                    throw new Exception("Could not find question");
                }

                var questionToReturn = _mapper.Map<Question, QuestionDto>(question);

                return questionToReturn;
            }
        }
    }
}