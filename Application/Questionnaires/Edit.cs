using System;
using System.Collections.Generic;
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

                questionnaire.Title = request.Title ?? questionnaire.Title;
                questionnaire.Description = request.Description ?? questionnaire.Description;
                questionnaire.Target = request.Target ?? questionnaire.Target;
                questionnaire.Creator = request.Creator ?? questionnaire.Creator;
                questionnaire.LastEdited = request.Date ?? DateTime.Now;
                //questionnaire.Questions = request.Questions ?? questionnaire.Questions;

                if (request.Questions != null)
                {
                    foreach (var reqQuest in request.Questions)
                    {
                        foreach (var domainQuest in questionnaire.Questions)
                        {
                            if (reqQuest.Id == domainQuest.Id)
                            {

                                Console.WriteLine(reqQuest.Id);
                                Console.WriteLine(domainQuest.Id);

                                Questions.Edit.Command qCommand = new Questions.Edit.Command();
                                qCommand.Title = reqQuest.Title;
                                qCommand.Description = reqQuest.Description;
                                qCommand.Category = reqQuest.Category;
                                qCommand.Questionnaire = questionnaire;
                                qCommand.Answers = (List<Answer>)reqQuest.Answers;

                                return await _mediator.Send(qCommand);
                            }

                            else
                            {

                                Questions.Create.Command qCommand = new Questions.Create.Command();
                                qCommand.Id = reqQuest.Id;
                                qCommand.Title = reqQuest.Title;
                                qCommand.Description = reqQuest.Description;
                                qCommand.Category = reqQuest.Category;
                                qCommand.Questionnaire = questionnaire;
                                qCommand.Answers = (List<Answer>)reqQuest.Answers;

                                return await _mediator.Send(qCommand);
                            }
                        }
                    }
                }

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}