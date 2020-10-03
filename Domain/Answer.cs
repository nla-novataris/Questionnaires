using System;
using System.Collections.Generic;

namespace Domain
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}