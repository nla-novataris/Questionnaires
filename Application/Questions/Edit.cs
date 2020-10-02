using System;
using System.Collections.Generic;
using System.Linq;
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
            public ICollection<Answer> Answers { get; set; }
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
                var question = await _context.Questions.FindAsync(request.Id);

                if (question == null)
                {
                    throw new Exception("Could not find question");
                }

                question.Title = request.Title ?? question.Title;
                question.Description = request.Description ?? question.Description;
                question.Category = request.Category ?? question.Category;
                question.Questionnaire = request.Questionnaire ?? question.Questionnaire;
                
                
                //question.Answers = request.Answers ?? question.Answers;
              
                //if (request.Answers != null)
                //{
                //    foreach (var reqAnswer in request.Answers)
                //    {
                //        //Console.WriteLine(reqAnswer.Id);
                //        //Console.WriteLine(reqAnswer.Description);

                //        var value = question.Answers.First(item => item.Id == reqAnswer.Id);

                //        if (value != null)
                //        {
                //            Console.WriteLine("value");
                //            Console.WriteLine(value.Id);

                //            Answers.Edit.Command aCommand = new Answers.Edit.Command();
                //            aCommand.Id = reqAnswer.Id;
                //            aCommand.Description = reqAnswer.Description;
                //            aCommand.Question = question;

                //            return await _mediator.Send(aCommand);
                //        }

                //        else
                //        {
                //            Answers.Create.Command aCommand = new Answers.Create.Command();
                //            aCommand.Id = reqAnswer.Id;
                //            aCommand.Description = reqAnswer.Description;
                //            aCommand.Question = question;
                //            return await _mediator.Send(aCommand);
                //        }
                //    }
                //}


                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}