using System.Collections.Generic;

namespace DTOs
{
    public class UserStatisticsDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public List<CourseDto> FinishedCourses { get; set; }
        public List<ThemeDto> FinishedThemes { get; set; }
        public List<PracticalTaskDto> FinishedTasks { get; set; }
    }
}
