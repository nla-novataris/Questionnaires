using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Answers
{
    public class List
    {
        public class Query : IRequest<List<Answer>> { }

        public class Handler : IRequestHandler<Query, List<Answer>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Answer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var answers = await _context.Answers.ToListAsync();

                return answers;
            }
        }
    }
}