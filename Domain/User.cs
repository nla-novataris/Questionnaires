using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Category { get; set; }
        public DateTime Date { get; set; }  
        public string City { get; set; }    
        public string Venue { get; set; }    
        // public ICollection<UserAnswer> UserAnswers { get; set; }    
    }
}