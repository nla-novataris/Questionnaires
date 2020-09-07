using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questionnaires
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int? Target { get; set; }
            public User Creator { get; set; }
            public DateTime? Date { get; set; }
         
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

                var questionnaire = await _context.Questionnaires.FindAsync(request.Id);

                if (questionnaire == null)
                {
                    throw new Exception("Could not find activity");
                }

                questionnaire.Title = request.Title ?? questionnaire.Title; 
                questionnaire.Description = request.Description ?? questionnaire.Description; 
                questionnaire.Target = request.Target ?? questionnaire.Target; 
                // questionnaire.Creator = request.Creator ?? questionnaire.Creator;  
                questionnaire.LastEdited = request.Date ?? DateTime.Now;      

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}