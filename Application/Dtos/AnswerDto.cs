using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public ICollection<UserAnswerDto> UserAnswers { get; set; }
    }
}
