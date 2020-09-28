using System;

namespace Application.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        //public QuestionDto Description { get; set; }
     
        //   public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
