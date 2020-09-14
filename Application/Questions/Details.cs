using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questions
{
    public class Details
    {
        public class Query : IRequest<Question>
        {
            public Guid Id { get; set; }

        }

        public class Handler : IRequestHandler<Query, Question>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)

            {
                this._context = context;
            }

            public async Task<Question> Handle(Query request, CancellationToken cancellationToken)
            {
                var question = await _context.Questions.FindAsync(request.Id);

                if (question == null)
                {
                    throw new Exception("Could not find question");
                }

                return question;
            }
        }
    }
}