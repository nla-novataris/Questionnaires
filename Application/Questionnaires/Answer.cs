using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using Domain;
using MediatR;
using Persistence;

namespace Application.Questionnaires
{
    public class Answer
    {
        public class Command : IRequest
        {
            //Answer id
            public Guid AnswerId { get; set; }
            public string UserId { get; set; }
            
            public ICollection<UserAnswer> UserAnswers { get; set; }
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
                    _context.UserAnswers.Add(answered);
                }


                //Users.SingleOrDefault(x => x.UserName == 
                //_userAccessor.GetCurrentUsername());

                //var answered = await _context.UserAnswers.
                //         SingleOrDefault(x => x.AnswerId == questionnaire.Id &&
                //         x.UserId == user.Id);
                // Se om han allerede har svaret

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}