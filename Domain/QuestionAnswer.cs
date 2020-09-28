using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class QuestionAnswer
    {
        public Guid QuestionID { get; set; }
        public virtual Question Question { get; set; }
        public Guid AnswerID { get; set; }
        public virtual Answer Answer { get; set; }

    }
}
