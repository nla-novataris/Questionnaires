using System;
using System.Collections.Generic;
using System.Linq;
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

                var questionnaire = await _context.Questionnaires.FindAsync(request.Id);

                if (questionnaire == null)
                {
                    throw new Exception("Could not find Qs");
                }

                List<Question> qs = null;
                if (request.Questions != null)
                {   
                    foreach (var item in request.Questions)
                    {   

                        Console.WriteLine("item " + item);
                        Console.WriteLine("item " + item.Description);

                        if (!questionnaire.Questions.Any(n => n.Id == item.Id))
                            if (qs == null)
                            {
                                qs = new List<Question>();
                            }
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

                questionnaire.Title = request.Title ?? questionnaire.Title;
                questionnaire.Description = request.Description ?? questionnaire.Description;
                questionnaire.Target = request.Target ?? questionnaire.Target;
                questionnaire.Creator = request.Creator ?? questionnaire.Creator;
                questionnaire.LastEdited = request.Date ?? DateTime.Now;
                questionnaire.Questions = qs ?? questionnaire.Questions;

                //foreach (var reqQuest in request.Questions)
                //{
                //    count++;
                //    Console.WriteLine($"Element #{count}:");
                //    Console.WriteLine(request.Questions.IndexOf(reqQuest));
                //    Console.WriteLine(request.Questions.Count());
                //    Console.WriteLine(questionnaire.Questions.Count());

                //    var value = questionnaire.Questions.First(item => item.Id == reqQuest.Id);

                //    if (value != null)
                //    {
                //        Console.WriteLine("value");
                //        Console.WriteLine(value.Id);

                //        Questions.Edit.Command qCommand = new Questions.Edit.Command();
                //        qCommand.Id = reqQuest.Id;
                //        qCommand.Title = reqQuest.Title;
                //        qCommand.Description = reqQuest.Description;
                //        qCommand.Category = reqQuest.Category;
                //        qCommand.Questionnaire = questionnaire;
                //        qCommand.Answers = (List<Answer>)reqQuest.Answers;
                //        // return await _mediator.Send(qCommand);


                //       // await Questions.Edit.Handler.Handle(qCommand, new CancellationToken());
                //        return await _mediator.Send(qCommand);
                //    }
                //    else
                //    {
                //        Questions.Create.Command qCommand = new Questions.Create.Command();
                //        qCommand.Id = reqQuest.Id;
                //        qCommand.Title = reqQuest.Title;
                //        qCommand.Description = reqQuest.Description;
                //        qCommand.Category = reqQuest.Category;
                //        qCommand.Questionnaire = questionnaire;
                //        qCommand.Answers = (List<Answer>)reqQuest.Answers;
                //        return await _mediator.Send(qCommand);
                //    }
                //}

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}