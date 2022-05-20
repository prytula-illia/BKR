using System.Collections.Generic;

namespace DTOs
{
    public class UserStatisticsDto
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public int Rating { get; set; }
        public List<int> FinishedCourses { get; set; }
        public List<int> FinishedThemes { get; set; }
        public List<int> FinishedTasks { get; set; }
    }
}
