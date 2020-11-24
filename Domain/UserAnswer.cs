using System;

namespace Domain
{
    public class UserAnswer
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public Guid AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        
        
        public DateTime AnswerDate { get; set; }
    }
}
