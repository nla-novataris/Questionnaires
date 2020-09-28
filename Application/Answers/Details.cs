using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Answers
{
    public class Details
    {
        public class Query : IRequest<Answer>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Answer>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)

            {
                this._context = context;
            }

            public async Task<Answer> Handle(Query request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answers.FindAsync(request.Id);

                if (answer == null)
                {
                    throw new Exception("Could not find answer");
                }
                return answer;
            }
        }
    }
}