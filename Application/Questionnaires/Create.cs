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
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Target { get; set; }
            public User Creator { get; set; }
            public DateTime? Date { get; set; }
            public ICollection<Question> Questions { get; set; }

        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                this._context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                List<Question> qs = new List<Question>();
                foreach (var item in request.Questions)
                {
                    Console.WriteLine("item "+ item);
                    var question = new Question
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description
                    };
                    qs.Add(question);

                //    var questionAnswers = new QuestionAnswer
                //    {
                //        QuestionID = item.Id,
                //        Question = question,
                //        AnswerID = 
                //        Answer
                //}

                }

                Console.WriteLine("quest " + qs);

              

                var questionnaire = new Questionnaire
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Target = request.Target,
                    //Creator = request.Creator,
                    Started = request.Date ?? DateTime.Now,
                    Questions = qs
                };

                //_context.QuestionAnswers.Add();
                _context.Questionnaires.Add(questionnaire);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}