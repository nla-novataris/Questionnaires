using System;

namespace Domain
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}