using System.Collections.Generic;

namespace DTOs
{
    public class PracticalTaskDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionTypeDto Type { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public int ThemeId { get; set; }
    }
}
