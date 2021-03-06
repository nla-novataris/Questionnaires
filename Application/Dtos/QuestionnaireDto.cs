﻿using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class QuestionnaireDto
    {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Target { get; set; }
            public UserDto Creator { get; set; }
            public DateTime Started { get; set; }
            public DateTime LastEdited { get; set; }
            public DateTime Answered { get; set; }
            public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();


    }
}
