using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Questionnaires
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        //public QuestionDto Description { get; set; }
     
        //   public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
