using System.Collections.Generic;

namespace DAL.Entities
{
    public class PracticalTask
    {
        public string Question { get; set; }
        public QuestionType Type { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
