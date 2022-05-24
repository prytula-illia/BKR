using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PracticalTask
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionType Type { get; set; }
        public List<Answer> Answers { get; set; }
        public Theme Theme { get; set; }
    }
}
