using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Dtos;


namespace Application.Questionnaires
{
    public class List
    {
        public class Query : IRequest<List<QuestionnaireDto>> { }

        public class Handler : IRequestHandler<Query, List<QuestionnaireDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<QuestionnaireDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //include user?

                // var questionnaires = await _context.Questionnaires.ToListAsync();
                var questionnaires = await _context.Questionnaires
                    //.Include(x => x.Questions)
                    //.ThenInclude(x => x.QuestionAnswers)
                    //.ThenInclude(x => x.Answer)
                    //.Include(x => x.Creator)
                    .ToListAsync();


                //foreach (var item in questionnaires)
                //{
                //    Console.WriteLine("item");
                //    Console.WriteLine(item);
                //    Console.WriteLine(item.Questions);
                //    foreach (var item2 in item.Questions)
                //    {
                //        Console.WriteLine(item2.Description);

                //        Console.WriteLine(item2.QuestionAnswers);
                //        Console.WriteLine("qa's");
                //        Console.WriteLine(item2.QuestionAnswers.Count);
                //        foreach (var item3 in item2.QuestionAnswers)
                //        {
                //            Console.WriteLine(item3.Answer.Description);
                //        }
                //    }
                //}

                //foreach (var questionnaireItem in questionnaires)
                //{
                //    Console.WriteLine("item");
                //    foreach (var question in questionnaireItem.Questions)
                //    {
                //        Console.WriteLine(question.Description);

                //        var ques = questionnaires[0].Questions;

                //        var ans = new List<Answer>();

                //        foreach (var question1 in ques)
                //        {
                //            question1.QuestionAnswers[0].
                //            ans.Add();
                //        }
                //    }
                //}

                

                var questionnaireToReturn = _mapper.Map<List<Questionnaire>, List<QuestionnaireDto>>(questionnaires);


                //var questionnaireToReturn = _mapper.Map<Questionnaire, QuestionnaireDto>(questionnaire);
                //var questionnairesToReturn = 
                //return questionnairesToReturn;
                return questionnaireToReturn;
            }
        }
    }
}