using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Answers
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Description { get; set; }
            public Question Question { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                Console.WriteLine("lol");
                var answer = new Answer
                {
                    Id = request.Id,
                    Description = request.Description,
                    Question = request.Question
                };

                _context.Answers.Add(answer);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}