using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Questionnaires
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();

    }
}
