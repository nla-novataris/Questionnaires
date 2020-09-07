using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questionnaires
{
    public class Details
    {
        public class Query : IRequest<Questionnaire>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Questionnaire>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)

            {
                this._context = context;

            }

            public async Task<Questionnaire> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionnaire = await _context.Questionnaires.FindAsync(request.Id);

                return questionnaire;
            }
        }
    }
}