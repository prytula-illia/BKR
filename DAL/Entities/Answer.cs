using System.Collections.Generic;

namespace DAL.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public List<PracticalTask> Tasks { get; set; }
    }
}
