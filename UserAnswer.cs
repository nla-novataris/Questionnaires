using System;

namespace Domain
{
    public class UserAnswer
    {
        public Guid Id { get; set; }
        public Answer Answer { get; set; }
        public string AnswerId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public DateTime DateAnswered { get; set; }
        public bool IsLocked { get; set; }
    }
}