using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questions
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public Questionnaire Questionnaire { get; set; }
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

                var question = await _context.Questions.FindAsync(request.Id);

                if (question == null)
                {
                    throw new Exception("Could not find question");
                }

                question.Title = request.Title ?? question.Title;
                question.Description = request.Description ?? question.Description;
                question.Category = request.Category ?? question.Category;
                question.Questionnaire = request.Questionnaire ?? question.Questionnaire;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}