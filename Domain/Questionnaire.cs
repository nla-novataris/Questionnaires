using System;
using System.Collections.Generic;

namespace Domain
{
    public class Questionnaire
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description  { get; set; }
        public int Target { get; set; }
        public User Creator { get; set; } 
        public DateTime Started { get; set; }  
        public DateTime LastEdited { get; set; }  
        public DateTime Answered { get; set; }
        public ICollection<Question> Questions { get; set; }    

    }
}