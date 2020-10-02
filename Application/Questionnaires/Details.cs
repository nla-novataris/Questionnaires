using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using Application.Dtos;

namespace Application.Questionnaires
{
    public class Details
    {
        public class Query : IRequest<QuestionnaireDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, QuestionnaireDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)

            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<QuestionnaireDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionnaire = await _context.Questionnaires
                    .FindAsync(request.Id);

                var questionnaireToReturn = _mapper.Map<Questionnaire, QuestionnaireDto>(questionnaire);

                //foreach (var question in questionnaire.Questions)
                //{
                //    foreach (var qa in question.QuestionAnswers)
                //    {
                //        Console.WriteLine(qa.Question.Description);
                //        Console.WriteLine(qa.Answer.Description);
                        
                //        domainAnswers.Add(qa.Answer);
                //    }
                //    var dtoAnswers = _mapper.Map<List<Answer>, List<AnswerDto>>(domainAnswers);
                //}

                //var qs = questionnaireToReturn.Questions;

                if (questionnaire == null)
                {
                    throw new Exception("Could not find questionnaire");
                }

                return questionnaireToReturn;
            }
        }
    }
}