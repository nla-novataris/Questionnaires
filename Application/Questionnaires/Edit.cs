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
            public string Id { get; set; }
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
                //questionnaire.Questions = qs ?? questionnaire.Questions;

                var success = await _context.SaveChangesAsync() > 0;

                if (request.Questions.Count > 0)
                {
                    foreach (var requestQuestion in request.Questions)
                    {
                        List<Question> questions = (List<Question>)questionnaire.Questions;

                        // Hvis Questionnaire ikke indeholder et sp�rgsm�l med requestQuestion's id skal det oprettes som nyt
                        if (null == (questions.Find(x => x.Id == requestQuestion.Id)))
                        {
                            Questions.Create.Command qCommand = new Questions.Create.Command();
                            qCommand.Id = requestQuestion.Id;
                            qCommand.Title = requestQuestion.Title;
                            qCommand.Description = requestQuestion.Description;
                            qCommand.Category = requestQuestion.Category;
                            qCommand.Questionnaire = questionnaire;
                            qCommand.Answers = (List<Domain.Answer>)requestQuestion.Answers;
                            var successQ = await _mediator.Send(qCommand);
                        }
                        // Ellers skal der rettes
                        else
                        {
                            Questions.Edit.Command qCommand = new Questions.Edit.Command();
                            qCommand.Id = requestQuestion.Id;
                            qCommand.Title = requestQuestion.Title;
                            qCommand.Description = requestQuestion.Description;
                            qCommand.Category = requestQuestion.Category;
                            qCommand.Questionnaire = questionnaire;
                            qCommand.Answers = (List<Domain.Answer>)requestQuestion.Answers;
                            var successQ = await _mediator.Send(qCommand);
                        }
                    }
                }

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}