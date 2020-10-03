using System;
using System.Collections.Generic;

namespace Domain
{
    public class Questionnaire
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description  { get; set; }
        public int Target { get; set; }
        public virtual User Creator { get; set; } 
        public DateTime Started { get; set; }  
        public DateTime LastEdited { get; set; }  
        public DateTime Answered { get; set; }
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();


    }
}