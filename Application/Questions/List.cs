using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Questions
{
    public class List
    {
        public class Query : IRequest<List<QuestionDto>> { }

        public class Handler : IRequestHandler<Query, List<QuestionDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<QuestionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var questions = await _context.Questions.ToListAsync();
                List<QuestionDto> returnQuestions = _mapper.Map<List<Question>, List<QuestionDto>>(questions);
                return returnQuestions;
            }
        }
    }
}