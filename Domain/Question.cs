using System;
using System.Collections.Generic;

namespace Domain
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        //public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }

    }
}