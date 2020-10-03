using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questionnaires
{
    public class UnAnswer
    {
        public class Command : IRequest
        {
            public ICollection<UserAnswer> UserAnswers { get; set; }
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
                foreach (var answer in request.UserAnswers)
                {
                    var dbAnswer = await _context.Answers
                        .FindAsync(answer.AnswerId);
                    var user = await _context.Users
                        .FindAsync(answer.UserId);

                    var answered = new UserAnswer
                    {
                        Answer = dbAnswer,
                        User = user,
                        AnswerDate = DateTime.Now
                    };
                    _context.UserAnswers.Remove(answered);
                }

                if (request.UserAnswers == null) return Unit.Value;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}