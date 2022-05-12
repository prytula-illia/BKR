using System.Collections.Generic;

namespace DTOs
{
    public class QuestionDto
    {
        public string Content { get; set; }

        public QuestionTypeDto Type { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
