using System;
using System.Collections.Generic;

namespace Domain
{
    public class TextQuestion
    {


        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
        
    }
}