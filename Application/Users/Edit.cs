using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Users
{
    public class Edit
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool? IsAdmin { get; set; }
            public DateTime Added { get; set; }
            public Questionnaire Questionnaire { get; set; }
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
                var user = await _context.Users.FindAsync(request.Id);

                if (user == null)
                {
                    throw new Exception("Could not find user");
                }

                user.UserName = request.UserName ?? user.UserName;
                user.FirstName = request.FirstName ?? user.FirstName;
                user.LastName = request.LastName ?? user.LastName;

                if (request.Questionnaire != null)
                {
                    user.Questionnaires.Add(request.Questionnaire);
                }
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}