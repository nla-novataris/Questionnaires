using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Questionnaires
{
    public class List
    {
        public class Query : IRequest<List<Questionnaire>> { }

        public class Handler : IRequestHandler<Query, List<Questionnaire>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<List<Questionnaire>> Handle(Query request, CancellationToken cancellationToken)
            {

                var questionnaires = await _context.Questionnaires.ToListAsync();

                return questionnaires;
            }
        }
    }
}