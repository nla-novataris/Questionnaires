using System;

namespace Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsAdmin { get; set; }
        //public List<QuestionnaireDto> Questionnaires { get; set; } = new List<QuestionnaireDto>();
        public DateTime Added { get; set; }

        // public ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
