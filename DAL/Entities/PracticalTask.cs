using System.Collections.Generic;

namespace DAL.Entities
{
    public class PracticalTask
    { 
        public List<Question> Questions { get; set; }
        public int Score { get; set; }
    }
}
