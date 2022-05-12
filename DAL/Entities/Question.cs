using System.Collections.Generic;

namespace DAL.Entities
{
    public class Question
    {
        public string Content { get; set; }

        public QuestionType Type { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
