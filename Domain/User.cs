using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        private string _username;

        public override string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAdmin { get; set; }
        public virtual List<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>();
        public DateTime Added { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}