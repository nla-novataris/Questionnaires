using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questionnaires
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Target { get; set; }
            public AppUser Creator { get; set; }
            public DateTime? Date { get; set; }
            public ICollection<Question> Questions { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMediator _mediator;

            public Handler(DataContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                List<Question> qs = new List<Question>();

                if (request.Questions != null && request.Questions.Count > 0)
                {
                    foreach (var item in request.Questions)
                    {
                        Console.WriteLine("item " + item);
                        var question = new Question
                        {
                            Id = item.Id,
                            Title = item.Title,
                            Description = item.Description,
                            Answers = item.Answers
                        };
                        qs.Add(question);
                    }
                }

                var questionnaire = new Questionnaire
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Target = request.Target,
                    Creator = request.Creator ?? request.Creator,
                    Started = request.Date ?? DateTime.Now,
                    Questions = qs
                };

                _context.Questionnaires.Add(questionnaire);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}