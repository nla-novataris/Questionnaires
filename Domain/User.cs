using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        public string Id { get; set; }
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAdmin { get; set; }
        public virtual List<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public DateTime Added { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}