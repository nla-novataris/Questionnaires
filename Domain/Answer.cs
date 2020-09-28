using System;

namespace Domain
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual Question Question { get; set; }
        
        //public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}